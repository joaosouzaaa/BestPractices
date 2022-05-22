using BestPractices.ApplicationService.DTO_s.Response.User;

namespace BestPractices.ApplicationService.Interfaces
{
    public interface ITokenManagerService
    {
        Task<string> GenerateAccessToken(UserResponse clientUserResponse);
    }
}
