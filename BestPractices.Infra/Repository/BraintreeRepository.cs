using BestPractices.Business.Interfaces.Repository;
using Braintree;
using Microsoft.Extensions.Configuration;

namespace BestPractices.Infra.Repository
{
    public class BraintreeRepository : IBraintreeRepository
    {
        private readonly IConfiguration _configuration;

        public BraintreeRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public BraintreeGateway CreateGateway()
        {
            var gateway = new BraintreeGateway
            {
                Environment = Braintree.Environment.SANDBOX,
                MerchantId = _configuration["Braintree:MerchantId"],
                PublicKey = _configuration["Braintree:PublicKey"],
                PrivateKey = _configuration["Braintree:PrivateKey"]
            };

            return gateway;
        }
    }
}
