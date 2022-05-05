using BestPractices.ApplicationService.Interfaces;
using BestPractices.ApplicationService.Services;
using Microsoft.Extensions.DependencyInjection;

namespace BestPractices.IndependencyInjection.DependencyInjectionSettings.ServicesConfiguration
{
    public static class ServicesConfiguration
    {
        public static void AddServiceConfiguration(this IServiceCollection services)
        {
            services.AddScoped<IClientService, ClientService>();
        }
    }
}
