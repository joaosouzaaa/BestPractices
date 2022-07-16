using BestPractices.Business.Settings.PaginationSettings;

namespace BestPractices.Business.Interfaces.Pagination
{
    public interface IPagingService<TEntity>
    {
        Task<PageList<TEntity>> CreatePaginationAsync(IQueryable<TEntity> source, int pageNumber, int pageSize);
    }
}
