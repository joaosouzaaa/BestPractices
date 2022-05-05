using BestPractices.ApplicationService.AutoMapperSettings;
using BestPractices.Business.Interfaces.Notification;
using BestPractices.Business.Interfaces.Validation;
using BestPractices.Business.NotificationSettings;
using BestPractices.Business.ValidationSettings;
using Microsoft.Extensions.DependencyInjection;

namespace BestPractices.IndependencyInjection.DependencyInjectionSettings.OthersConfiguration
{
    public static class SettingOthersConfigurations
    {
        public static void AddOthersConfiguration(this IServiceCollection services)
        {
            services.AddScoped<INotificationHandler, NotificationHandler>();
            services.AddScoped<IValidationHandler, ValidationHandler>();

            AutoMapperHandler.Inicialize();
        }
    }
}
