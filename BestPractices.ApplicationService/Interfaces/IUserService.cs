using BestPractices.ApplicationService.Request.User;
using BestPractices.ApplicationService.Response.BearerToken;
using BestPractices.ApplicationService.Response.User;
using BestPractices.Business.Settings.PaginationSettings;

namespace BestPractices.ApplicationService.Interfaces
{
    public interface IUserService
    {
        Task<bool> RegisterAsync(UserSaveRequest userSaveRequest);
        Task<BearerTokenResponse> LoginAsync(UserSaveRequest userSaveRequest);
        Task<bool> UpdateAsync(UserUpdateRequest updateRequest);
        Task<UserResponseClient> GetUserByEmailAsync(string email);
        Task<bool> DeleteAsync(string userId);
        Task<List<UserResponseClient>> FindAllEntitiesAsync();
        Task<PageList<UserResponseClient>> FindAllEntitiesWithPaginationAsync(PageParams pageParams);
    }
}
