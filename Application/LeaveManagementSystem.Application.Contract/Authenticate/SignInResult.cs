namespace LeaveManagementSystem.Application.Contract.Authenticate
{
    public class SignInResult
    {
        public SignInResult()
        {
            TokenInfo = new TokenInfo();
        }
        public SignInStatusEnum SignInStatus { get; set; }
        public TokenInfo TokenInfo { get; set; }
    }
}
