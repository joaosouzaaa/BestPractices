namespace BestPractices.ApplicationService.Interfaces.BaseService
{
    public interface IBaseService<TSave, TUpdate, TResponse> 
        where TSave : class
        where TUpdate : class
        where TResponse : class
    {
        Task SaveAsync(TSave clientSaveRequest);
        Task UpdateAsync(TUpdate clientUpdateRequest);
        Task DeleteAsync(int id);
        Task<TResponse> FindByIdAsync(int id);
        Task<IEnumerable<TResponse>> FindAllEntitiesAsync();
    }
}
