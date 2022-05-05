using BestPractices.Business.Interfaces.Notification;
using FluentValidation.Results;

namespace BestPractices.Business.NotificationSettings
{
    public class NotificationHandler : INotificationHandler
    {
        private readonly List<DomainNotification> _notifications;

        public NotificationHandler()
        {
            this._notifications = new List<DomainNotification>();
        }

        public List<DomainNotification> GetNotifications() => this._notifications;

        public bool HasNotification() => this._notifications.Any();

        public void AddNotification(DomainNotification notification)
        {
            this._notifications.Add(notification);
        }

        public void AddNotification(string key, string value)
        {
            this._notifications.Add(new DomainNotification(key, value));
        }

        public void AddNotifications(IEnumerable<DomainNotification> notifications)
        {
            this._notifications.AddRange(notifications);
        }

        public void AddNotifications(ValidationResult validationResult)
        {
            foreach (var error in validationResult.Errors)
            {
                AddNotification(error.ErrorCode, error.ErrorMessage);
            }
        }
    }
}
