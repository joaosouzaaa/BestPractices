using BestPractices.Business.Interfaces.Pagination;
using BestPractices.Business.Interfaces.Repository;
using BestPractices.Business.Interfaces.Repository.RepositoryBase;
using BestPractices.Domain.Entities;
using BestPractices.Domain.Entities.EntityBase;
using BestPractices.Infra.Contexts;
using BestPractices.Infra.Repository.RepositoryBase;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace BestPractices.Infra.Repository
{
    public class SupplierRepository : BaseQueryRepository<Supplier>, ISupplierRepository
    {
        public SupplierRepository(IPagingService<Supplier> pagingService, UserDbContext context) : base(pagingService, context)
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

        public async Task<bool> GenericExistAsync<TEntity>(int id) where TEntity : BaseEntity =>
            await _context.Set<TEntity>().AnyAsync(e => e.Id == id);

        public override Task<bool> UpdateAsync(Supplier entity)
        {
            _context.Entry(entity.CompanyAddress).State = EntityState.Modified;

            return base.UpdateAsync(entity);
        }
    }
}
