using BestPractices.Business.Interfaces.Notification;
using BestPractices.Business.Interfaces.Validation;
using FluentValidation;

namespace BestPractices.ApplicationService.Services.ServiceBase
{
    public class BaseService
    {
        private IValidationHandler _validationHandler;
        protected INotificationHandler _notificationHandler;

        public BaseService(IValidationHandler validationHandler, INotificationHandler notificationHandler)
        {
            this._validationHandler = validationHandler;
            this._notificationHandler = notificationHandler;
        }

        protected void IsNullObject<TEntity>(TEntity entity)
        {
            if (entity == null)
            {
                this._notificationHandler.AddNotification("Inválido", "Formulário vazio");
            }
        }

        public async Task<bool> ValidatedAsync<TEntity, TValidate>(TEntity entity, TValidate validate)
            where TEntity : class
            where TValidate : AbstractValidator<TEntity>
        {
            var entityResult = await _validationHandler.ValidateAsync(entity, validate);

            if (!entityResult)
            {
                this._notificationHandler.AddNotifications(_validationHandler.validationResult);
            }

            return entityResult;
        }
    }
}
