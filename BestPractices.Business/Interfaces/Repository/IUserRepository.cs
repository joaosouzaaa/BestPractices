using BestPractices.Business.Settings.PaginationSettings;
using BestPractices.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Query;
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
        Task<User> FindByIdAsync(string id);
        Task<IdentityResult> DeleteAsync(string userId);
        Task<bool> HaveObjectInDb(Expression<Func<User, bool>> where);
        Task<List<User>> GetAllAsync(Func<IQueryable<User>, IIncludableQueryable<User, object>> include);
        Task<PageList<User>> FindAllWithPaginationAsync(PageParams pageParams, Func<IQueryable<User>, IIncludableQueryable<User, object>> include);
    }
}
