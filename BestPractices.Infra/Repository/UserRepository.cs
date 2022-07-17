using BestPractices.Business.Interfaces.Pagination;
using BestPractices.Business.Interfaces.Repository;
using BestPractices.Business.Settings.PaginationSettings;
using BestPractices.Domain.Entities;
using BestPractices.Infra.Contexts;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace BestPractices.Infra.Repository
{
    public class UserRepository : IUserRepository
    {
        protected UserDbContext _context;
        protected DbSet<User> DbContextSet => _context.Set<User>();
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IPagingService<User> _pagingService;

        public UserRepository(UserManager<User> userManager, SignInManager<User> signInManager, UserDbContext context, IPagingService<User> pagingService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
            _pagingService = pagingService;
        }

        public async Task<IdentityResult> RegisterAsync(User user)
        {
            var userToBeCreated = new User()
            {
                UserName = user.Email,
                Email = user.Email,
                PasswordHash = user.PasswordHash,
                Client = user.Client
            };

            return await _userManager.CreateAsync(userToBeCreated, userToBeCreated.PasswordHash);
        }

        public async Task<SignInResult> LoginAsync(string email, string password) => await _signInManager.PasswordSignInAsync(email, password, false, false);

        public async Task<IdentityResult> UpdateAsync(User user) =>
            await _userManager.UpdateAsync(user);

        public async Task<User> GetUserByEmailAsync(string email) => await DbContextSet.Include(cu => cu.Client).FirstOrDefaultAsync(cu => cu.Email == email);

        public async Task<User> GetUserByIdAsync(string id) => await DbContextSet.Include(cu => cu.Client).FirstOrDefaultAsync(cu => cu.Id == id);

        public async Task<User> FindByIdAsync(string id) =>
            await _userManager.FindByIdAsync(id);

        public async Task<IdentityResult> DeleteAsync(string userId) =>
            await _userManager.DeleteAsync(await _userManager.FindByIdAsync(userId));

        public async Task<bool> HaveObjectInDb(Expression<Func<User, bool>> where) => await DbContextSet.AsNoTracking().AnyAsync(where);

        public async Task<List<User>> GetAllAsync(Func<IQueryable<User>, IIncludableQueryable<User, object>> include)
        {
            var query = DbContextSet.AsNoTracking();

            if (include != null)
                query = include(query);

            return await query.ToListAsync();
        }

        public async Task<PageList<User>> FindAllWithPaginationAsync(PageParams pageParams, Func<IQueryable<User>, IIncludableQueryable<User, object>> include)
        {
            var query = DbContextSet.AsNoTracking();

            if (include != null)
                query = include(query);

            return await _pagingService.CreatePaginationAsync(query, pageParams.pageNumber, pageParams.pageSize);
        }
    }
}
