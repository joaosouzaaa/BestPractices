namespace BestPractices.ApplicationService.Interfaces.BaseService
{
    public interface IBaseService<TSave, TUpdate> 
        where TSave : class
        where TUpdate : class
    {
        Task<bool> SaveAsync(TSave clientSaveRequest);
        Task<bool> UpdateAsync(TUpdate clientUpdateRequest);
        Task<bool> DeleteAsync(int id);
    }
}
