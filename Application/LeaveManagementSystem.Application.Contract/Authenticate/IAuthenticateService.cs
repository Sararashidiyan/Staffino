using System.Collections.Generic;
using System.Threading.Tasks;

namespace LeaveManagementSystem.Application.Contract.Authenticate
{
    public interface IAuthenticateService
    {
        Task<SignInResult> Authenticate(LoginDto loginInfo);
    }
}
