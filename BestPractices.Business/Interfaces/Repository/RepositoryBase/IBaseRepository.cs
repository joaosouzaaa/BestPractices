using BestPractices.Domain.Entities.EntityBase;
using System.Linq.Expressions;

namespace BestPractices.Business.Interfaces.Repository.RepositoryBase
{
    public interface IBaseRepository<TEntity> : IAsyncDisposable
        where TEntity : BaseEntity
    {
        Task<bool> SaveAsync(TEntity entity);
        Task<bool> UpdateAsync(TEntity entity);
        Task<bool> DeleteAsync(int id);
        Task<bool> LogicalDeleteAsync(int id);
        Task<bool> EntityExistAsync(int id);
        Task<TEntity> GetEntityByProperty(Expression<Func<TEntity, bool>> predicate);
    }
}
