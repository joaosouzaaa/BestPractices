using BestPractices.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System.Linq.Expressions;

namespace BestPractices.Business.Interfaces.Repository
{
    public interface IUserRepository
    {
        Task<IdentityResult> RegisterAsync(User user);
        Task<SignInResult> LoginAsync(string email, string password);
        Task<IdentityResult> UpdateAsync(User user);
        Task <User> GetUserByEmailAsync(string email);
        Task<User> GetUserByIdAsync(string id);
        Task<string> GenerateEmailConfirmationTokenAsync(User user);
        Task<IdentityResult> ConfirmEmailAsync(User user, string token);
        Task<IdentityResult> DeleteAsync(string userId);
        Task<bool> HaveObjectInDb(Expression<Func<User, bool>> where);
    }
}
