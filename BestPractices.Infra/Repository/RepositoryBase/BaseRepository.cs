using BestPractices.Business.Interfaces.Repository.RepositoryBase;
using BestPractices.Domain.Entities.EntityBase;
using BestPractices.Infra.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BestPractices.Infra.Repository.RepositoryBase
{
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity>
        where TEntity : BaseEntity
    {
        protected readonly UserDbContext _context;
        public virtual DbSet<TEntity> DbContextSet => _context.Set<TEntity>();

        public BaseRepository(UserDbContext context)
        {
            _context = context;
        }

        private async Task<bool> Save() => await _context.SaveChangesAsync() > 0;

        public virtual async Task<bool> SaveAsync(TEntity entity)
        {
            DbContextSet.Add(entity);

            _context.Entry(entity).State = EntityState.Added;

            return await Save();
        }

        public virtual async Task<bool> UpdateAsync(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;

            return await Save();
        }

        public virtual async Task<bool> DeleteAsync(int id)
        {
            var entity = await GetEntity(id);

            _context.Entry(entity).State = EntityState.Deleted;

            return await Save();
        }

        public virtual async Task<bool> LogicalDeleteAsync(int id)
        {
            var entity = await GetEntity(id);
            entity.Excluded = true;

            _context.Entry(entity).State = EntityState.Modified;

            return await Save();
        }

        public virtual async Task<bool> EntityExistAsync(int id) => await DbContextSet.AnyAsync(c => c.Id == id);

        public virtual async Task<TEntity> GetEntityByProperty(Expression<Func<TEntity, bool>> predicate) => await DbContextSet.AsNoTracking().FirstOrDefaultAsync(predicate);

        private async Task<TEntity> GetEntity(int id) => await DbContextSet.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

        async ValueTask IAsyncDisposable.DisposeAsync() => await _context.DisposeAsync();
    }
}
