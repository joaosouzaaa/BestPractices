using BestPractices.Api.Filters;

namespace BestPractices.Api.Configuration
{
    public static class FiltersConfiguration
    {
        public static void AddFiltersConfiguration(this IServiceCollection services)
        {
            services.AddMvc(config =>
            {
                config.Filters.AddService<NotificationFilter>();
            });

            services.AddScoped<NotificationFilter>();
        }
    }
}
