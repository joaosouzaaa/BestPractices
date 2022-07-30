using BestPractices.ApplicationService.AutoMapperSettings;
using BestPractices.ApplicationService.Response.BearerToken;
using BestPractices.Domain.Entities;
using ExpectedObjects;

namespace UnitTests.AutoMapperTests
{
    public class BearerTokenAutoMapperTests
    {
        public BearerToken BearerToken = BearerTokenBuilder.NewObject().DomainBuild();

        public BearerTokenAutoMapperTests()
        {
            AutoMapperHandler.Inicialize();
        }

        [Fact]
        public void BearerToken_To_BearerTokenResponse() =>
            BearerToken.MapTo<BearerToken, BearerTokenResponse>().ToExpectedObject().ShouldMatch(BearerToken);
    }
}
