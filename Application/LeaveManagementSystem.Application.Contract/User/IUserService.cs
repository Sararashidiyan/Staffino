using System.Threading.Tasks;

namespace LeaveManagementSystem.Application.Contract.User
{
    public interface IUserService
    {
        Task<UserDto> GetCurrentUser();
    }
}
