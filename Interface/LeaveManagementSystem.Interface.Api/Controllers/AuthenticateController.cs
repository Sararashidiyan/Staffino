using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LeaveManagementSystem.Application.Contract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace LeaveManagementSystem.Interface.Api.Controllers
{

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
        public async Task<ActionResult> Login()
        {
            var loginResult = await _authenticateService.Login();
            if (loginResult.SignInStatus == SignInStatusEnum.OK)
                return Ok(new { token = loginResult.TokenInfo.Token, expiration = loginResult.TokenInfo.Expiration });
            return Unauthorized();
        }
    }
}
