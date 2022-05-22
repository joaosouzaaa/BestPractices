using BestPractices.DependencyInjection.DependencyInjectionSettings.IdentityConfiguration;
using BestPractices.IndependencyInjection.DependencyInjectionSettings.OthersConfiguration;
using BestPractices.IndependencyInjection.DependencyInjectionSettings.RepositoriesConfiguration;
using BestPractices.IndependencyInjection.DependencyInjectionSettings.ServicesConfiguration;
using BestPractices.Infra.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BestPractices.IndependencyInjection
{
    public static class HandlerConfiguration
    {
        public static void SettingsHandler(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<UserDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });

            services.AddIdentityConfiguration(configuration);
            services.AddServiceConfiguration();
            services.AddRepositoryConfiguration();
            services.AddOthersConfiguration();
        }
    }
}
