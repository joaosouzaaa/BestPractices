using BestPractices.ApplicationService.AutoMapperSettings;
using BestPractices.Business.Interfaces.Notification;
using BestPractices.Business.Settings.NotificationSettings;
using Microsoft.Extensions.DependencyInjection;

namespace BestPractices.DependencyInjection.DependencyInjectionSettings
{
    public static class OthersConfigurations
    {
        public static void AddOthersConfigurations(this IServiceCollection services)
        {
            services.AddScoped<INotificationHandler, NotificationHandler>();

            AutoMapperHandler.Inicialize();
        }
    }
}
