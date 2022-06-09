using BestPractices.Domain.Entities;

namespace BestPractices.Business.Interfaces.Repository.RepositoryBase
{
    public interface IBaseRepository<TEntity> : IAsyncDisposable
        where TEntity : BaseEntity
    {
        Task Save(TEntity entity);
        Task Update(TEntity entity);
        Task Delete(int id);
        Task LogicalDelete(int id);
        Task<TEntity> GetEntity(int id);
        Task<IEnumerable<TEntity>> GetAllEntities();
        bool EntityExist(int id);
    }
}
