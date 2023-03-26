using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace LeaveManagementSystem.Interface.Api.CustomActionFilters
{
    public class CacheAttribute : ActionFilterAttribute
    {
        public TimeSpan ClientDuration { get; set; }
        public TimeSpan ServerDuration { get; set; }
        public string Tags { get; set; }
     
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (ClientDuration != TimeSpan.Zero)
                context.HttpContext.Items[Constants.ClientDuration] = ClientDuration;
            if (ServerDuration != TimeSpan.Zero)
                context.HttpContext.Items[Constants.ServerDuration] = ServerDuration;
            if (!string.IsNullOrWhiteSpace(Tags))
                context.HttpContext.Items[Constants.Tags] = Tags;

            var ss = context.HttpContext.Items[Constants.ServerDuration];
            base.OnActionExecuting(context);
        }
    }
    public static class Constants
    {
        public static string ClientDuration => "ClientDuration";
        public static string Tags => "Tags";
        public static string AllTag => "AllTag";
        public static string ServerDuration => "ServerDuration";
        public static string CacheTagPrefix => "CKP";
    }
}
