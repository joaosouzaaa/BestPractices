using BestPractices.Business.Settings.NotificationSettings;
using FluentValidation.Results;

namespace BestPractices.Business.Interfaces.Notification
{
    public interface INotificationHandler
    {
        List<DomainNotification> GetNotifications();
        bool HasNotification();
        bool AddNotification(DomainNotification notification);
        void AddNotification(string key, string value);
        void AddNotifications(IEnumerable<DomainNotification> notifications);
        void AddNotifications(ValidationResult validationResult);
    }
}
