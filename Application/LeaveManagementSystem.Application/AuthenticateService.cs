﻿using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using LeaveManagementSystem.Application.Contract.Authenticate;
using LeaveManagementSystem.Security.AspIdentity;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;
using SignInResult = LeaveManagementSystem.Application.Contract.Authenticate.SignInResult;

namespace LeaveManagementSystem.Application
{
    public class AuthenticateService : IAuthenticateService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;
        public AuthenticateService(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
        }

        public async Task<SignInResult> Authenticate(LoginDto loginInfo)
        {
            //var user = await _userManager.FindByIdAsync(loginInfo.UserName);
            //var isPasswordValid = await _userManager.CheckPasswordAsync(user, loginInfo.Password);
            //if (user != null && isPasswordValid)
            //{
            //var userRoles = await _userManager.GetRolesAsync(user);
            var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier,Guid.NewGuid().ToString()),
                    new Claim(ClaimTypes.Name, /*user.UserName*/"sara"),
                    new Claim(ClaimTypes.DateOfBirth,"2000-02-02"),
                    new Claim("permission", "canReadResource"),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };

            //foreach (var userRole in userRoles)
            //{
            authClaims.Add(new Claim(ClaimTypes.Role, /*userRole*/"admin"));
            //}
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddHours(3),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
            );
            return new SignInResult()
            {
                TokenInfo = { Token = new JwtSecurityTokenHandler().WriteToken(token), Expiration = token.ValidTo },
                SignInStatus = SignInStatusEnum.OK
            };
            //}

            //return new SignInResult(){SignInStatus=SignInStatusEnum.Unauthorized}; 
        }



    }
}
