using LeaveManagementSystem.Application.Contract;
using LeaveManagementSystem.Application.Contract.User;
using LeaveManagementSystem.Interface.Api.Attributes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using LeaveManagementSystem.Interface.Api.CustomActionFilters;

namespace LeaveManagementSystem.Interface.Api.Controllers.SecurityControllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        public UserController()
        {

        }
        [HttpGet]
        [Route("Info")]
        public ActionResult GetCurrentUser()
        {
            var currentUser = HttpContext.User.Identity as ClaimsIdentity;
            if (currentUser == null || currentUser.Claims.Count() == 0)
            {
                return NotFound();
            }
            var userInfo = new UserDto { UserName = currentUser.Name, Role = currentUser.Claims.FirstOrDefault(s => s.Type == ClaimTypes.Role)?.Value };
            return Ok(userInfo);
        }
    }
}
