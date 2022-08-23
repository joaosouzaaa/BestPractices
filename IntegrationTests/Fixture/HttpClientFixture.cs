using BestPractices.ApplicationService.Response.BearerToken;
using BestPractices.Business.Settings.PaginationSettings;
using BestPractices.Infra.Contexts;
using Builders;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;

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

        protected async Task<HttpStatusCode> CreatePostAsync<TEntity>(string route, TEntity entity) where TEntity : class
        {
            var httpResponse = await _httpClient.PostAsJsonAsync(route, entity);
            return httpResponse.StatusCode;
        }

        protected async Task<HttpStatusCode> CreatePutAsync<TEntity>(string route, TEntity entity) where TEntity : class
        {
            var httpResponse = await _httpClient.PutAsJsonAsync(route, entity);
            return httpResponse.StatusCode;
        }

        protected async Task<HttpStatusCode> CreateDeleteAsync(string route)
        {
            var httpResponse = await _httpClient.DeleteAsync(route);
            return httpResponse.StatusCode;
        }

        protected async Task<TEntity> CreateGetAsync<TEntity>(string route) =>
            await _httpClient.GetFromJsonAsync<TEntity>(route);

        protected async Task<List<TEntity>> CreateGetAllAsync<TEntity>(string route) where TEntity : class =>
            await _httpClient.GetFromJsonAsync<List<TEntity>>(route);

        protected async Task<PageList<TEntity>> CreateGetAllPageListAsync<TEntity>(string route) where TEntity : class =>
            await _httpClient.GetFromJsonAsync<PageList<TEntity>>(route);

        protected async Task AuthenticateAsync() =>
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await CreateProfileAndLoginAsync());

        private async Task<string> CreateProfileAndLoginAsync()
        {
            var userSaveRequest = UserBuilder.NewObject().SaveRequestBuild();
            var registerHttpResponse = await _httpClient.PostAsJsonAsync("api/User/register", userSaveRequest);
            
            if (registerHttpResponse.IsSuccessStatusCode)
            {
                var loginHttpResponse = await _httpClient.PostAsJsonAsync("api/User/login", userSaveRequest);
                var bearerTokenResponse = await loginHttpResponse.Content.ReadFromJsonAsync<BearerTokenResponse>();
                return bearerTokenResponse.Token;
            }

            return null;
        }
    }
}
