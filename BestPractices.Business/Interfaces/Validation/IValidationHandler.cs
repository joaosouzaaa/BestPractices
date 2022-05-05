using FluentValidation;
using FluentValidation.Results;

namespace BestPractices.Business.Interfaces.Validation
{
    public interface IValidationHandler
    {
        public ValidationResult validationResult { get; }
        bool Validate<TEntity>(TEntity entity, AbstractValidator<TEntity> validator);
        Task<bool> ValidateAsync<TEntity>(TEntity entity, AbstractValidator<TEntity> validator);
    }
}
