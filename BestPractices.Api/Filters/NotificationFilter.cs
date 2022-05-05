using BestPractices.Business.Interfaces.Notification;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BestPractices.Api.Filters
{
    public class NotificationFilter : ActionFilterAttribute
    {
        private readonly INotificationHandler _notification;

        public NotificationFilter(INotificationHandler notification)
        {
            this._notification = notification;
        }

        public override void OnActionExecuted(ActionExecutedContext actionContext)
        {
            if (this._notification.HasNotification())
            {
                actionContext.Result = new BadRequestObjectResult(this._notification.GetNotifications());
            }

            base.OnActionExecuted(actionContext);
        }
    }
}
