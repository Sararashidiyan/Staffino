using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LeaveManagementSystem.Application.Contract.Authenticate;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace LeaveManagementSystem.Interface.Api.Controllers.SecurityControllers
{
    [AllowAnonymous]
    [ApiController]
    [Route("[controller]")]
    public class AuthenticateController : ControllerBase
    {
        private readonly IAuthenticateService _authenticateService;
        public AuthenticateController(IAuthenticateService authenticateService)
        {
            _authenticateService = authenticateService;
        }

        [HttpPost]
        [Route("Login")]
        public async Task<ActionResult> Login(LoginDto loginInfo)
        {

            var loginResult = await _authenticateService.Authenticate(loginInfo);
            if (loginResult.SignInStatus == SignInStatusEnum.OK)
                return Ok(new { token = loginResult.TokenInfo.Token, expiration = loginResult.TokenInfo.Expiration });
            return Unauthorized();
        }
    }
}
