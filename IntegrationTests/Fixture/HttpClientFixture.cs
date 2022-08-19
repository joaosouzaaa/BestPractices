using BestPractices.Infra.Contexts;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using System.Linq;
using System.Net.Http;

namespace IntegrationTests.Fixture
{
    public abstract class HttpClientFixture
    {
        protected readonly HttpClient _httpClient;

        protected HttpClientFixture()
        {
            var root = new InMemoryDatabaseRoot();

            var appFactory = new WebApplicationFactory<Program>()
                .WithWebHostBuilder(builder =>
                {
                    builder.ConfigureServices(services =>
                    {
                        var descriptor = services.SingleOrDefault(
                            d => d.ServiceType ==
                                typeof(DbContextOptions<UserDbContext>));

                        services.Remove(descriptor);
                        services.AddDbContext<UserDbContext>(options =>
                        {
                            options.UseInMemoryDatabase("DbForTests", root);
                        });
                    });
                });

            _httpClient = appFactory.CreateClient();
        }
    }
}
