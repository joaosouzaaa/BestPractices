using BestPractices.ApplicationService.Interfaces;
using BestPractices.ApplicationService.Services;
using Microsoft.Extensions.DependencyInjection;

namespace BestPractices.DependencyInjection.DependencyInjectionSettings
{
    public static class ServicesConfiguration
    {
        public static void AddServiceConfiguration(this IServiceCollection services)
        {
            services.AddScoped<IClientService, ClientService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ITokenManagerService, TokenManagerService>();
            services.AddScoped<IBraintreeService, BraintreeService>();
        }
    }
}
