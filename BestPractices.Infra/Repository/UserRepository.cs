using BestPractices.Business.Interfaces.Repository;
using BestPractices.Domain.Entities;
using BestPractices.Infra.Contexts;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BestPractices.Infra.Repository
{
    public class UserRepository : IUserRepository
    {
        protected UserDbContext _context;
        protected DbSet<User> Dbset => this._context.Set<User>();
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

            var result = await _userManager.CreateAsync(userToBeCreated, userToBeCreated.PasswordHash);

            return result;
        }

        public async Task<SignInResult> LoginAsync(string email, string password)
        {
            return await _signInManager.PasswordSignInAsync(email, password, false, false);
        }

        public async Task<User> GetUserByEmailAsync(string email)
        {
            var user = await Dbset.Include(cu => cu.Client).FirstOrDefaultAsync(cu => cu.Email == email);
            return user;
        }
    }
}
