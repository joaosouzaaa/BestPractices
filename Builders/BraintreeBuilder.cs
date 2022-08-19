using BestPractices.ApplicationService.Response.Braintree;

namespace Builders
{
    public class BraintreeBuilder
    {
        private string _clientToken = Guid.NewGuid().ToString();

        public static BraintreeBuilder NewObject()
        {
            return new BraintreeBuilder();
        }

        public BraintreeResponse ResponseBuild()
        {
            return new BraintreeResponse
            {
                ClientToken = _clientToken
            };
        }
    }
}
