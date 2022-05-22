using System.Security.Claims;

namespace BestPractices.Api.Extensions
{
    public static class ProfileExtension
    {
        public static string GetUserEmail(this HttpContext httpContext)
        {
            if (httpContext == null)
            {
                return string.Empty;
            }

            var identity = httpContext.User.Identity as ClaimsIdentity;

            IEnumerable<Claim> claim = identity.Claims;

            var usernameClaim = claim
                .Where(x => x.Type == ClaimTypes.Email)
                .FirstOrDefault().Value;

            return usernameClaim;
        }
    }
}
