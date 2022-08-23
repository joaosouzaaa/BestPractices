using BestPractices.ApplicationService.Interfaces;
using BestPractices.ApplicationService.Services;
using Microsoft.Extensions.DependencyInjection;

namespace BestPractices.DependencyInjection.DependencyInjectionSettings
{
    public static class ServicesConfiguration
    {
        public static void AddServiceConfiguration(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ITokenManagerService, TokenManagerService>();
            services.AddScoped<IBraintreeService, BraintreeService>();
            services.AddScoped<IShoppingCartService, ShoppingCartService>();
            services.AddScoped<ISupplierService, SupplierService>();
            services.AddScoped<IProductService, ProductService>();
        }
    }
}
