using BestPractices.Business.Interfaces.Repository.RepositoryBase;
using BestPractices.Domain.Entities;
using BestPractices.Infra.Contexts;
using Microsoft.EntityFrameworkCore;

namespace BestPractices.Infra.Repository.RepositoryBase
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity>
        where TEntity : BaseEntity
    {
        private readonly UserDbContext _context;
        protected DbSet<TEntity> DbSet => _context.Set<TEntity>();

        public BaseRepository(UserDbContext context)
        {
            _context = context;
        }

        private async Task Save() => await _context.SaveChangesAsync();

        public async Task Save(TEntity entity)
        {
            DbSet.Add(entity);

            _context.Entry(entity).State = EntityState.Added;

            await Save();
        }

        public async Task Update(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;

            await Save();
        }

        public async Task Delete(int id)
        {
            var entity = await GetEntity(id);

            _context.Entry(entity).State = EntityState.Deleted;

            await Save();
        }

        public async Task LogicalDelete(int id)
        {
            var entity = await GetEntity(id);
            entity.Excluded = true;

            _context.Entry(entity).State = EntityState.Modified;

            await Save();
        }

        public async Task<TEntity> GetEntity(int id) => await DbSet.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

        public async Task<IEnumerable<TEntity>> GetAllEntities() => await DbSet.AsNoTracking().ToListAsync();

        public bool EntityExist(int id) => DbSet.Any(c => c.Id == id);

        async ValueTask IAsyncDisposable.DisposeAsync() => await _context.DisposeAsync();
    }
}
