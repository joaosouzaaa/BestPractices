using BestPractices.ApplicationService.AutoMapperSettings;
using BestPractices.ApplicationService.Interfaces;
using BestPractices.ApplicationService.Response.BearerToken;
using BestPractices.Domain.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BestPractices.ApplicationService.Services
{
    public class TokenManagerService : ITokenManagerService
    {
        private readonly IConfiguration _configuration;

        public TokenManagerService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<BearerTokenResponse> GenerateAccessToken(string email)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));

            var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                    new Claim(JwtRegisteredClaimNames.Email, email),
                }),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = signIn
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            var confirmToken = new JwtSecurityTokenHandler().WriteToken(token);

            var bearerToken = SetupToken(confirmToken);

            return bearerToken.MapTo<BearerToken, BearerTokenResponse>();
        }

        private BearerToken SetupToken(string token) => new BearerToken { Token = token };
    }
}
