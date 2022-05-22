using BestPractices.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace BestPractices.Business.Interfaces.Repository
{
    public interface IUserRepository
    {
        Task<IdentityResult> RegisterAsync(User user);
        Task<SignInResult> LoginAsync(string email, string password);
        Task<User> GetUserByEmailAsync(string email);
    }
}
