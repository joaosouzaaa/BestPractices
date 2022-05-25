using Braintree;

namespace BestPractices.Business.Interfaces.Repository
{
    public interface IBraintreeRepository
    {
        BraintreeGateway CreateGateway();
    }
}
