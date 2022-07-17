using BestPractices.Business.Interfaces.Repository;
using BestPractices.Infra.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace BestPractices.DependencyInjection.DependencyInjectionSettings
{
    public static class RepositoryConfiguration
    {
        public static void AddRepositoryConfiguration(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IBraintreeRepository, BraintreeRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IShoppingCartRepository, ShoppingCartRepository>();
            services.AddScoped<ISupplierRepository, SupplierRepository>();
        }
    }
}
