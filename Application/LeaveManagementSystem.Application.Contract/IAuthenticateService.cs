using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LeaveManagementSystem.Application.Contract
{
    public interface IAuthenticateService
    {
         Task<SignInResult> Login();
    }
    public enum SignInStatusEnum
    {
        OK,
        RequiresVerification,
        LockedOut,
        Unauthorized
    }
    public class SignInResult
    {
        public SignInStatusEnum SignInStatus { get; set; }
        public TokenInfo TokenInfo { get; set; }
    }
    public class TokenInfo
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
    }
}
