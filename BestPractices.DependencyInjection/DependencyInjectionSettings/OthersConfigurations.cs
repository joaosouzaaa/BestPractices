using BestPractices.ApplicationService.AutoMapperSettings;
using BestPractices.Business.Interfaces.Notification;
using BestPractices.Business.Settings.NotificationSettings;
using BestPractices.Domain.Entities.Email;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BestPractices.DependencyInjection.DependencyInjectionSettings
{
    public static class OthersConfigurations
    {
        public static void AddOthersConfigurations(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<INotificationHandler, NotificationHandler>();
            services.Configure<EmailConfig>(configuration.GetSection("EmailConfig"));

            AutoMapperHandler.Inicialize();
        }
    }
}
