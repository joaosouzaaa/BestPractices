using BestPractices.Business.Extensions;
using BestPractices.Business.Interfaces.Validation;
using FluentValidation;
using FluentValidation.Results;

namespace BestPractices.Business.Settings.ValidationSettings
{
    public abstract class Validate<TEntity> : AbstractValidator<TEntity>, IValidate<TEntity>
        where TEntity : class
    {
        private ValidationResult ValidationResult { get; set; }
        private Dictionary<string, string> GetErrors() => ValidationResult.Errors.ToDictionary();

        public async Task<ValidationResponse> ValidateAsync(TEntity entity)
        {
            ValidationResult = await base.ValidateAsync(entity);
            return ValidationResponse.CreateValidation(GetErrors());
        }
    }
}
