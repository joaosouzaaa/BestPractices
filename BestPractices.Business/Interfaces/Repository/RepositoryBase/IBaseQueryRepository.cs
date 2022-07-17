using BestPractices.Business.Settings.PaginationSettings;
using BestPractices.Domain.Entities.EntityBase;
using Microsoft.EntityFrameworkCore.Query;

namespace BestPractices.Business.Interfaces.Repository.RepositoryBase
{
    public interface IBaseQueryRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        Task<TEntity> GetById(int id, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null, bool asNoTracking = false);
        Task<List<TEntity>> GetAll(Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null);
        Task<PageList<TEntity>> FindAllWithPagination(PageParams pageParams, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null);
    }
}
