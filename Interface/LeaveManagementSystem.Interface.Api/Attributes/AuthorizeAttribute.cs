using System;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace LeaveManagementSystem.Interface.Api.Attributes
{
    public static class MyClaimTypes
    {
        public static string Permission => "Permission";
    }
    public enum PermissionItem
    {
        User,
        Product,
        Contact,
        Review,
        Client
    }

    public enum PermissionAction
    {
        Read,
        Create,
    }

    public class ClaimRequirementAttribute : TypeFilterAttribute
    {
        public ClaimRequirementAttribute(string claimType, string value) : base(typeof(ClaimRequirementActionFilter))
        {
            Arguments = new object[] { new Claim(claimType, value) };
        }
    }

    public class ClaimRequirementActionFilter : IAuthorizationFilter
    {
        private readonly Claim _claim;
        public ClaimRequirementActionFilter(Claim claim)
        {
            _claim = claim;
        }
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var hasClaim = context.HttpContext.User.Claims.Any(c=>c.Value==_claim.Value && c.Type==_claim.Type);
            if (!hasClaim) context.Result = new ForbidResult();
        }
        
    }

    public class Over18Requirement : AuthorizationHandler<Over18Requirement>, IAuthorizationRequirement
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, Over18Requirement requirement)
        {
            if (!context.User.HasClaim(c => c.Type == ClaimTypes.DateOfBirth))
            {
                context.Fail();
                return Task.CompletedTask;
            }

            var dobVal = context.User.FindFirst(c => c.Type == ClaimTypes.DateOfBirth).Value;
            var dateOfBirth = Convert.ToDateTime(dobVal);
            int age = DateTime.Today.Year - dateOfBirth.Year;
            if (dateOfBirth > DateTime.Today.AddYears(-age))
            {
                age--;
            }

            if (age >= 18)
            {
                context.Succeed(requirement);
            }
            else
            {
                context.Fail();
            }
            return Task.CompletedTask;
        }
    }
}
