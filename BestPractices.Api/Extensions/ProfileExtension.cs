using System.Security.Claims;

namespace BestPractices.Api.Extensions
{
    public static class ProfileExtension
    {
        public static string GetUserEmail(this HttpContext httpContext)
        {
            if (httpContext == null)
                return string.Empty;

            var identityClaims = httpContext.User.Identity as ClaimsIdentity;

            var claims = identityClaims.Claims;

            var usernameClaim = claims.Where(c => c.Type == ClaimTypes.Email).FirstOrDefault().Value;

            return usernameClaim;
        }
    }
}
