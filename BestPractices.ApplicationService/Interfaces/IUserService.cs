using BestPractices.ApplicationService.Request.User;
using BestPractices.ApplicationService.Response.BearerToken;
using BestPractices.ApplicationService.Response.User;

namespace BestPractices.ApplicationService.Interfaces
{
    public interface IUserService
    {
        Task<bool> RegisterAsync(UserSaveRequest userSaveRequest);
        Task<bool> ConfirmEmailAsync(string email, string token);
        Task<BearerTokenResponse> LoginAsync(UserSaveRequest userSaveRequest);
        Task<bool> UpdateAsync(UserUpdateRequest updateRequest);
        Task<UserResponseClient> GetUserByEmailAsync(string email);
        Task<bool> DeleteAsync(string userId);
    }
}
