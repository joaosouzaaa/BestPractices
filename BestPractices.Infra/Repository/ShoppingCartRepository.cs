using BestPractices.Business.Interfaces.Repository;
using BestPractices.Domain.Entities;
using BestPractices.Domain.Entities.EntityBase;
using BestPractices.Infra.Contexts;
using BestPractices.Infra.Repository.RepositoryBase;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace BestPractices.Infra.Repository
{
    public class ShoppingCartRepository : BaseRepository<ShoppingCart>, IShoppingCartRepository
    {
        public ShoppingCartRepository(UserDbContext context) : base(context)
        {
        }

        public async Task<TEntity> FindByGenericAsync<TEntity>(int id, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null, bool asNoTracking = false) where TEntity : BaseEntity
        {
            var query = (IQueryable<TEntity>)_context.Set<TEntity>();

            if (asNoTracking)
                query.AsNoTracking();

            if (include != null)
                query = include(query);

            return await query.FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<ShoppingCart> GetShoppingCart(int id) => await DbContextSet.Include(s => s.Products).Include(s => s.User).AsNoTracking().FirstOrDefaultAsync(s => s.Id == id);
    }
}
