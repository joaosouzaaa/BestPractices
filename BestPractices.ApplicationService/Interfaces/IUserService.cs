using BestPractices.ApplicationService.DTO_s.Request.User;
using BestPractices.ApplicationService.DTO_s.Response.User;

namespace BestPractices.ApplicationService.Interfaces
{
    public interface IUserService
    {
        Task<bool> RegisterAsync(UserSaveRequest userSaveRequest);
        Task<string> LoginAsync(UserSaveRequest userSaveRequest);
        Task<UserResponseClient> GetUserByEmailAsync(string email);
    }
}
