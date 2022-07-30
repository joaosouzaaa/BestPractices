﻿using BestPractices.Business.Interfaces.Notification;

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

            return true;
        }

        public void AddNotification(string key, string value) =>
            _notifications.Add(new DomainNotification(key, value));

        public void AddNotifications(IEnumerable<DomainNotification> notifications) =>
            _notifications.AddRange(notifications);

        public void AddNotifications(Dictionary<string, string> notifications)
        {
            foreach (var notification in notifications)
                AddNotification(notification.Key, notification.Value);
        }
    }
}
