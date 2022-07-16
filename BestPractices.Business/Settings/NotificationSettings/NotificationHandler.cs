using BestPractices.Business.Interfaces.Notification;
using FluentValidation.Results;

namespace BestPractices.Business.Settings.NotificationSettings
{
    public class NotificationHandler : INotificationHandler
    {
        private readonly List<DomainNotification> _notifications;

        public NotificationHandler()
        {
            _notifications = new List<DomainNotification>();
        }

        public List<DomainNotification> GetNotifications() => _notifications;

        public bool HasNotification() => _notifications.Any();

        public bool AddNotification(DomainNotification notification)
        {
            _notifications.Add(notification);

            if (HasNotification() == true)
                return false;
            else
                return true;
        }

        public void AddNotification(string key, string value) =>
            _notifications.Add(new DomainNotification(key, value));

        public void AddNotifications(IEnumerable<DomainNotification> notifications) =>
            _notifications.AddRange(notifications);

        public void AddNotifications(ValidationResult validationResult)
        {
            foreach (var error in validationResult.Errors)
                AddNotification(error.ErrorCode, error.ErrorMessage);
        }
    }
}
