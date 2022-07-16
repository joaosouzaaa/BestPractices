using BestPractices.Business.Settings.ValidationSettings;

namespace BestPractices.Business.Interfaces.Validation
{
    public interface IValidate<TEntity> where TEntity : class
    {
        Task<ValidationResponse> ValidateAsync(TEntity entity);
    }
}
