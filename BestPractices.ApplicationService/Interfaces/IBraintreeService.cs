using BestPractices.ApplicationService.Request.Braintree;
using BestPractices.ApplicationService.Response.Braintree;
using Braintree;

namespace BestPractices.ApplicationService.Interfaces
{
    public interface IBraintreeService
    {
        Task<BraintreeResponse> GenerateClientToken();
        Transaction CreateTransaction(BraintreeSaveRequest braintreeSaveRequest);
        Task<Transaction> GetTransaction(string id);
    }
}
