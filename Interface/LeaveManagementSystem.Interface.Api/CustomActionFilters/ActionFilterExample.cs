using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using LeaveManagementSystem.Application.Contract;

namespace LeaveManagementSystem.Interface.Api.CustomActionFilters
{
    public class ValidationFilterAttribute : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var param = context.ActionArguments.FirstOrDefault(a => a.Value is Dto);
            if (param.Value == null)
                context.Result = new NotFoundObjectResult(param);
            if (!context.ModelState.IsValid)
                context.Result = new UnprocessableEntityObjectResult(context.ModelState);
        }
    }

}
