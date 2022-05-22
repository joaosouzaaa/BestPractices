using BestPractices.ApplicationService.DTO_s.Request.User;
using BestPractices.ApplicationService.DTO_s.Response.User;

namespace BestPractices.ApplicationService.Interfaces
{
    public interface IUserService
    {
        Task RegisterAsync(UserSaveRequest userSaveRequest);
        Task<UserResponse> LoginAsync(UserSaveRequest userSaveRequest);
        Task<UserResponseClient> GetUserByEmailAsync(string email);
    }
}
