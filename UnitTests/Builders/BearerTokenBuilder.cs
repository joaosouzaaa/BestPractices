using BestPractices.Domain.Entities;

namespace UnitTests.Builders
{
    public class BearerTokenBuilder
    {
        public static BearerTokenBuilder NewObject()
        {
            return new BearerTokenBuilder();
        }

        public BearerToken DomainBuild()
        {
            return new BearerToken
            {
                Token = "token here"
            };
        }
    }
}
