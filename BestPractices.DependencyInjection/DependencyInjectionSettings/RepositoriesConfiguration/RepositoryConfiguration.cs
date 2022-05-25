using BestPractices.Business.Interfaces.Repository;
using BestPractices.Infra.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace BestPractices.IndependencyInjection.DependencyInjectionSettings.RepositoriesConfiguration
{
    public static class RepositoryConfiguration
    {
        public static void AddRepositoryConfiguration(this IServiceCollection services)
        {
            services.AddScoped<IClientRepository, ClientRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IBraintreeRepository, BraintreeRepository>();
        }
    }
}
