using BestPractices.Business.Interfaces.Validation;
using BestPractices.Business.Settings.ValidationSettings.EntitiesValidation;
using BestPractices.Domain.Entities;
using Microsoft.Extensions.DependencyInjection;

namespace BestPractices.DependencyInjection.DependencyInjectionSettings
{
    public static class ValidationConfiguration
    {
        public static void AddValidationConfiguration(this IServiceCollection services)
        {
            services.AddScoped<IValidate<Client>, ClientValidation>();
            services.AddScoped<IValidate<User>, UserValidation>();
        }
    }
}
