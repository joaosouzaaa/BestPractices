using BestPractices.Business.Settings.PaginationSettings;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Query;
using Moq;
using System.Security.Claims;
using System.Text;

namespace Builders.Helpers
{
    public class Utils
    {
        public static PageList<TEntity> PageListBuilder<TEntity>(List<TEntity> pageListEntities)
        {
            return new PageList<TEntity>
            {
                CurrentPage = 1,
                PageSize = 10,
                Result = pageListEntities,
                TotalCount = pageListEntities.Count,
                TotalPages = 1
            };
        }

        public static IFormFile BuildIFormFile()
        {
            var bytes = Encoding.UTF8.GetBytes("This is a dummy file");
            return new FormFile(new MemoryStream(bytes), 0, bytes.Length, "Data", "image.jpg")
            {
                Headers = new HeaderDictionary(),
                ContentType = "image/jpeg",
                ContentDisposition = "form-data; name=\"Image\"; filename=\"image.jpg\""
            };
        }

        public static ClaimsPrincipal BuildClaimPrincipal(string name, Guid userId, string actor, string email)
        {
            return new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.Name, name),
                new Claim(ClaimTypes.NameIdentifier, userId.ToString()),
                new Claim(ClaimTypes.Actor, actor),
                new Claim(ClaimTypes.Email, email)
            }));
        }

        public static Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> BuildIQueryableIncludeFunc<TEntity>() where TEntity : class =>
            It.IsAny<Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>>();
    }
}
