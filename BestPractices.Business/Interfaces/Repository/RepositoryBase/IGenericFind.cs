using BestPractices.Domain.Entities.EntityBase;
using Microsoft.EntityFrameworkCore.Query;

namespace BestPractices.Business.Interfaces.Repository.RepositoryBase
{
    public interface IGenericFind
    {
        Task<TEntity> FindByGenericAsync<TEntity>(int id, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null, bool asNoTracking = false)
            where TEntity : BaseEntity;
    }
}
