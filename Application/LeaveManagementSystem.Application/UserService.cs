using System.Threading.Tasks;
using LeaveManagementSystem.Application.Contract.User;

namespace LeaveManagementSystem.Application
{
    public class UserService : IUserService
    {
        public Task<UserDto> GetCurrentUser()
        {
            return null;
           //var currentUser=
        }
    }
}
