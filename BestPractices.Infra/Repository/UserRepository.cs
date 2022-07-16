using BestPractices.Business.Interfaces.Repository;
using BestPractices.Domain.Entities;
using BestPractices.Infra.Contexts;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BestPractices.Infra.Repository
{
    public class UserRepository : IUserRepository
    {
        protected UserDbContext _context;
        protected DbSet<User> DbContextSet => _context.Set<User>();
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public UserRepository(UserManager<User> userManager, SignInManager<User> signInManager, UserDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
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

        public async Task<string> GenerateEmailConfirmationTokenAsync(User user) => 
            await _userManager.GenerateEmailConfirmationTokenAsync(user);

        public async Task<IdentityResult> ConfirmEmailAsync(User user, string token) => 
            await _userManager.ConfirmEmailAsync(user, token);

        public async Task<IdentityResult> DeleteAsync(string userId) =>
            await _userManager.DeleteAsync(await _userManager.FindByIdAsync(userId));

        public async Task<bool> HaveObjectInDb(Expression<Func<User, bool>> where) => await DbContextSet.AsNoTracking().AnyAsync(where);
    }
}
