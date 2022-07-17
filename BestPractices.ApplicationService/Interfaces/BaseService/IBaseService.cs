namespace BestPractices.ApplicationService.Interfaces.BaseService
{
    public interface IBaseService<TSave, TUpdate> 
        where TSave : class
        where TUpdate : class
    {
        Task<bool> SaveAsync(TSave saveRequest);
        Task<bool> UpdateAsync(TUpdate updateRequest);
        Task<bool> DeleteAsync(int id);
    }
}
