using BestPractices.ApplicationService.Response.BearerToken;

namespace BestPractices.ApplicationService.Interfaces
{
    public interface ITokenManagerService
    {
        Task<BearerTokenResponse> GenerateAccessToken(string email);
    }
}
