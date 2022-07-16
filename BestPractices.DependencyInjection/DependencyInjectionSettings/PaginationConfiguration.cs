using BestPractices.Business.Interfaces.Pagination;
using BestPractices.Domain.Entities;
using BestPractices.Infra.Services;
using Microsoft.Extensions.DependencyInjection;

namespace BestPractices.DependencyInjection.DependencyInjectionSettings
{
    public static class PaginationConfiguration
    {
        public static void AddPaginationConfiguration(this IServiceCollection services)
        {
            services.AddScoped<IPagingService<Client>, PagingService<Client>>();
            services.AddScoped<IPagingService<Product>, PagingService<Product>>();
            services.AddScoped<IPagingService<Supplier>, PagingService<Supplier>>();
        }
    }
}
