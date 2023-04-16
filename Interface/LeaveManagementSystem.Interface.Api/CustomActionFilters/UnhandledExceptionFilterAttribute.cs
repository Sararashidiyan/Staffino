using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System.Net;
using LeaveManagementSystem.Core;

namespace LeaveManagementSystem.Interface.Api.CustomActionFilters
{
    public class UnhandledExceptionFilterAttribute : ExceptionFilterAttribute
    {
        private readonly ILogger<UnhandledExceptionFilterAttribute> _logger;

        public UnhandledExceptionFilterAttribute(ILogger<UnhandledExceptionFilterAttribute> logger)
        {
            _logger = logger;
        }
        public override void OnException(ExceptionContext context)
        {
            var statusCode = (int)HttpStatusCode.InternalServerError;
            if (context.Exception is BusinessException)
                statusCode = BusinessExceptionStatusCode;
            var result = new ObjectResult(new
            {
                context.Exception.Message,
                context.Exception.Source,
                ExceptionType = context.Exception.GetType().FullName,
            })
            {
                StatusCode = statusCode,
            };
            _logger.LogError("Unhandled exception occurred while executing request: {ex}", context.Exception);
            context.Result = result;
        }
        private static int BusinessExceptionStatusCode => 600;
    }
}