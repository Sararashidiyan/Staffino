using System;

namespace LeaveManagementSystem.Application.Contract.Authenticate
{
    public class TokenInfo
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
    }
}
