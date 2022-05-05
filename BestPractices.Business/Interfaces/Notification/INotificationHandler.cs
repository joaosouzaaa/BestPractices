using BestPractices.Business.NotificationSettings;
using FluentValidation.Results;

namespace BestPractices.Business.Interfaces.Notification
{
    public interface INotificationHandler
    {
        bool HasNotification();
        List<DomainNotification> GetNotifications();
        void AddNotification(DomainNotification notification);
        void AddNotification(string key, string value);
        void AddNotifications(IEnumerable<DomainNotification> notifications);
        void AddNotifications(ValidationResult validationResult);
    }
}
