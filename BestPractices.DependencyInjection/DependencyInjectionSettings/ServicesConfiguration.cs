using BestPractices.ApplicationService.Interfaces;
using BestPractices.ApplicationService.Interfaces.EmailService;
using BestPractices.ApplicationService.Services;
using BestPractices.ApplicationService.Services.EmailService;
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
            services.AddScoped<IEmailServiceConfig, EmailServiceConfig>();
            services.AddScoped<IEmailService, EmailService>();
        }
    }
}
