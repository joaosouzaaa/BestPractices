using BestPractices.Business.Interfaces.Repository;
using BestPractices.Domain.Entities;
using BestPractices.Infra.Contexts;
using BestPractices.Infra.Repository.RepositoryBase;
using Microsoft.EntityFrameworkCore;

namespace BestPractices.Infra.Repository
{
    public class ShoppingCartRepository : BaseRepository<ShoppingCart>, IShoppingCartRepository
    {
        public ShoppingCartRepository(UserDbContext context) : base(context)
        {
        }

        public async Task<ShoppingCart> FindShoppingCartWithProducts(int id) => 
            await DbSet.AsNoTracking()
            .Include(s => s.Products).AsNoTracking()
            .FirstOrDefaultAsync(p => p.Id == id);
    }
}
