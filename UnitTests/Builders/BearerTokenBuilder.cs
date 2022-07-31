using BestPractices.ApplicationService.Response.BearerToken;
using BestPractices.Domain.Entities;

namespace UnitTests.Builders
{
    public class BearerTokenBuilder
    {
        private string _token = "token here";

        public static BearerTokenBuilder NewObject()
        {
            return new BearerTokenBuilder();
        }

        public BearerToken DomainBuild()
        {
            return new BearerToken
            {
                Token = _token
            };
        }

        public BearerTokenResponse ResponseBuild()
        {
            return new BearerTokenResponse
            {
                Token = _token
            };
        }
    }
}
