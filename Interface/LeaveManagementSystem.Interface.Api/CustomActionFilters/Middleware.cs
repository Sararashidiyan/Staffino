using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Net.Http.Headers;

namespace LeaveManagementSystem.Interface.Api.CustomActionFilters
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class Middleware
    {
        private readonly RequestDelegate _next;
        private readonly ICacheClient _cache;

        public Middleware(RequestDelegate next)
        {
            _next = next;
            //using var scope = app.Services.CreateScope();
            //_cache = scope.ServiceProvider.GetRequiredService<CacheClient>();
        }
        private async Task<CachedPage> CaptureResponse(HttpContext context)
        {
            var responseStream = context.Response.Body;

            using var buffer = new MemoryStream();
            try
            {
                context.Response.Body = buffer;

                await _next.Invoke(context);
            }
            finally
            {
                context.Response.Body = responseStream;
            }

            if (buffer.Length == 0) return null;

            var bytes = buffer.ToArray(); // you could gzip here

            responseStream.Write(bytes, 0, bytes.Length);

            if (context.Response.StatusCode != 200) return null;

            return BuildCachedPage(context, bytes);
        }

        private CachedPage BuildCachedPage(HttpContext context, byte[] bytes)
        {
            return new CachedPage(bytes);
        }

        private async Task WriteResponse(HttpContext context, CachedPage page)
        {
            foreach (var header in page.Headers)
            {
                context.Response.Headers.Add(header);
            }

            await context.Response.Body.WriteAsync(page.Content, 0, page.Content.Length);
        }
        public async Task Invoke(HttpContext context)
        {
            var key = BuildCacheKey(context);

            if (_cache.TryGet(key, out CachedPage page))
            {
                await WriteResponse(context, page);

                return;
            }

            ApplyClientHeaders(context);

            if (IsNotServerCacheable(context))
            {
                await _next.Invoke(context);

                return;
            }

            page = await CaptureResponse(context);

            if (page != null)
            {
                var serverCacheDuration = GetCacheDuration(context, Constants.ServerDuration);

                if (serverCacheDuration != null)
                {
                    var tags = GetCacheTags(context, Constants.Tags);

                    _cache.Set(key, page, serverCacheDuration, tags);
                }
            }
        }

        private string[] GetCacheTags(HttpContext context, string tags)
        {
            return null;
        }

        private static TimeSpan GetCacheDuration(HttpContext context, string duration)
        {
            var serverDurationAsInt = Convert.ToInt32(context.Items[duration]);
            return new TimeSpan(0, serverDurationAsInt, 0);
        }

        private void ApplyClientHeaders(HttpContext context)
        {
            context.Response.OnStarting(() =>
            {
                var clientCacheDuration = GetCacheDuration(context, Constants.ClientDuration);

                if (clientCacheDuration != TimeSpan.Zero && context.Response.StatusCode == 200)
                {

                    context.Response.GetTypedHeaders().CacheControl = new CacheControlHeaderValue
                    {
                        Public = true,
                        MaxAge =clientCacheDuration
                    };
                }
                else
                {
                    context.Response.GetTypedHeaders().CacheControl = new CacheControlHeaderValue
                    {
                        NoCache = true,
                        NoStore = true,
                        MustRevalidate = true
                    };
                    context.Response.Headers["Expires"] = "0";
                }

                return Task.CompletedTask;
            });
        }

        private bool IsNotServerCacheable(HttpContext context)
        {
            var serverDurationAsInt = GetCacheDuration(context,Constants.ServerDuration);
            return serverDurationAsInt == TimeSpan.Zero;
        }

        private string BuildCacheKey(HttpContext context)
        {
            return "sa";
        }

    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseMyMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<Middleware>();
        }
    }
    internal class CachedPage
    {
        public byte[] Content { get; private set; }
        public List<KeyValuePair<string, StringValues>> Headers { get; private set; }

        public CachedPage(byte[] content)
        {
            Content = content;
            Headers = new List<KeyValuePair<string, StringValues>>();
        }
    }


    public interface ICacheClient
    {
        public bool TryGet<T>(string key, out T entry);
        public void Set(string key, object entry, object expiry, params string[] tags);
    }


    public class CacheClient : ICacheClient
    {
        private readonly IMemoryCache _cache;

        public CacheClient(IMemoryCache cache)
        {
            _cache = cache ?? throw new ArgumentNullException(nameof(cache));
        }
        public void Remove(string key)
        {
            _cache.Remove(Constants.CacheTagPrefix + key);
        }

        public void RemoveByTag(string tag)
        {
            if (_cache.TryGetValue(Constants.CacheTagPrefix + tag, out CancellationTokenSource tokenSource))
            {
                tokenSource.Cancel();

                _cache.Remove(Constants.CacheTagPrefix + tag);
            }
        }

        public void RemoveAll()
        {
            RemoveByTag(Constants.AllTag);
        }
        public bool TryGet<T>(string key, out T entry)
        {
            return _cache.TryGetValue(Constants.CacheTagPrefix + key, out entry);
        }

        public void Set(string key, object entry, object expiry, params string[] tags)
        {
            var options = new MemoryCacheEntryOptions
            {
                //AbsoluteExpirationRelativeToNow = expiry
            };

            var allTokenSource = _cache.GetOrCreate(Constants.CacheTagPrefix + Constants.AllTag,
                allTagEntry => new CancellationTokenSource());

            options.AddExpirationToken(new CancellationChangeToken(allTokenSource.Token));

            foreach (var tag in tags)
            {
                var tokenSource = _cache.GetOrCreate(Constants.CacheTagPrefix + tag, tagEntry =>
                {
                    tagEntry.AddExpirationToken(new CancellationChangeToken(allTokenSource.Token));

                    return new CancellationTokenSource();
                });

                options.AddExpirationToken(new CancellationChangeToken(tokenSource.Token));
            }

            _cache.Set(Constants.CacheTagPrefix + key, entry, options);
        }
    }



}
