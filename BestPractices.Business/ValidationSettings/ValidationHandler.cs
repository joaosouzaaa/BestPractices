using BestPractices.Business.Interfaces.Validation;
using FluentValidation;
using FluentValidation.Results;

namespace BestPractices.Business.ValidationSettings
{
    public class ValidationHandler : IValidationHandler
    {
        public ValidationResult validationResult { get; private set; }

        public bool Validate<TEntity>(TEntity entity, AbstractValidator<TEntity> validator)
        {
            this.validationResult = validator.Validate(entity);
            return this.validationResult.IsValid;
        }

        public async Task<bool> ValidateAsync<TEntity>(TEntity entity, AbstractValidator<TEntity> validator)
        {
            this.validationResult = await validator.ValidateAsync(entity);
            return this.validationResult.IsValid;
        }
    }
}
