using BestPractices.ApplicationService.DTO_s.Request.Braintree;
using BestPractices.ApplicationService.DTO_s.Response.Braintree;
using Braintree;

namespace BestPractices.ApplicationService.Interfaces
{
    public interface IBraintreeService
    {
        Task<BraintreeResponse> GenerateClientToken();
        Transaction CreateTransaction(BraintreeSaveRequest braintreeSaveRequest);
        Transaction GetTransaction(string id);
    }
}
