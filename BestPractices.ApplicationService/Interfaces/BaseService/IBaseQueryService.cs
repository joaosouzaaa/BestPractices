using BestPractices.Business.Settings.PaginationSettings;

namespace BestPractices.ApplicationService.Interfaces.BaseService
{
    public interface IBaseQueryService<TSave, TUpdate, TResponse> : IBaseService<TSave, TUpdate>
        where TSave : class
        where TUpdate : class
        where TResponse : class
    {
        Task<TResponse> FindByIdAsync(int id);
        Task<List<TResponse>> FindAllEntitiesAsync();
        Task<PageList<TResponse>> FindAllEntitiesWithPaginationAsync(PageParams pageParams);
    }
}
