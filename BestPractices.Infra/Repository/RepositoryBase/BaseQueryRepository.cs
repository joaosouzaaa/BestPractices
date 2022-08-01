using BestPractices.Business.Interfaces.Pagination;
using BestPractices.Business.Interfaces.Repository.RepositoryBase;
using BestPractices.Business.Settings.PaginationSettings;
using BestPractices.Domain.Entities.EntityBase;
using BestPractices.Infra.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace BestPractices.Infra.Repository.RepositoryBase
{
    public abstract class BaseQueryRepository<TEntity> : BaseRepository<TEntity>, IBaseQueryRepository<TEntity>
        where TEntity : BaseEntity
    {
        private readonly IPagingService<TEntity> _pagingService;

        public BaseQueryRepository(IPagingService<TEntity> pagingService, UserDbContext context) : base(context)
        {
            _pagingService = pagingService;
        }

        public virtual async Task<TEntity> GetById(int id, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include, bool asNoTracking)
        {
            var query = (IQueryable<TEntity>)DbContextSet;

            if (asNoTracking)
                query.AsNoTracking();

            if (include !=  null)
                query = include(query);

            return await query.FirstOrDefaultAsync(e => e.Id == id);
        }

        public virtual async Task<List<TEntity>> GetAll(Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include)
        {
            var query = DbContextSet.AsNoTracking();

            if (include != null)
                query = include(query);

            return await query.ToListAsync();
        }

        public virtual async Task<PageList<TEntity>> FindAllWithPagination(PageParams pageParams, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include)
        {
            var query = DbContextSet.AsNoTracking();

            if (include != null)
                query = include(query);

            return await _pagingService.CreatePaginationAsync(query, pageParams.pageNumber, pageParams.pageSize);
        }
    }
}
