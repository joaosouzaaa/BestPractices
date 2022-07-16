﻿using BestPractices.Business.Interfaces.Notification;

namespace BestPractices.ApplicationService.Services.ServiceBase
{
    public class BaseServiceNoValidation
    {
        protected readonly INotificationHandler _notification;

        public BaseServiceNoValidation(INotificationHandler notification)
        {
            _notification = notification;
        }
    }
}
