using BestPractices.Business.Interfaces.Notification;
using BestPractices.Business.Interfaces.Validation;
using BestPractices.Business.Settings.NotificationSettings;

namespace BestPractices.ApplicationService.Services.ServiceBase
{
    public abstract class BaseService<TEntity> where TEntity : class
    {
        protected readonly IValidate<TEntity> _validate;
        protected readonly INotificationHandler _notification;

        public BaseService(IValidate<TEntity> validate, INotificationHandler notification)
        {
            _validate = validate;
            _notification = notification;
        }

        public async Task<bool> ValidatedAsync(TEntity entity)
        {
            var validationResponse = await _validate.ValidateAsync(entity);

            if (!validationResponse.Valid)
                _notification.AddNotifications(DomainNotification.Create(validationResponse.Errors));

            return validationResponse.Valid;
        }
    }
}
