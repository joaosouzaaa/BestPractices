using BestPractices.ApplicationService.Interfaces;
using BestPractices.ApplicationService.Request.Braintree;
using BestPractices.ApplicationService.Response.Braintree;
using BestPractices.ApplicationService.Services.ServiceBase;
using BestPractices.Business.Extensions;
using BestPractices.Business.Interfaces.Notification;
using BestPractices.Business.Interfaces.Repository;
using BestPractices.Domain.Enums;
using Braintree;
using Microsoft.Extensions.Configuration;

namespace BestPractices.ApplicationService.Services
{
    public class BraintreeService : BaseServiceNoValidation, IBraintreeService
    {
        private readonly IBraintreeRepository _braintreeRepository;
        private readonly IConfiguration _configuration;
        private readonly TransactionStatus[] transactionSuccessStatuses =
        {
            TransactionStatus.AUTHORIZED,
            TransactionStatus.AUTHORIZING,
            TransactionStatus.SETTLED,
            TransactionStatus.SETTLING,
            TransactionStatus.SETTLEMENT_CONFIRMED,
            TransactionStatus.SETTLEMENT_PENDING,
            TransactionStatus.SUBMITTED_FOR_SETTLEMENT
        };

        public BraintreeService(INotificationHandler notificationHandler, IBraintreeRepository braintreeRepository, IConfiguration configuration)
            : base(notificationHandler)
        {
            _braintreeRepository = braintreeRepository;
            _configuration = configuration;
        }

        public async Task<BraintreeResponse> GenerateClientToken()
        {
            var gateway = _braintreeRepository.CreateGateway();

            var clientToken = await gateway.ClientToken.GenerateAsync();

            return new BraintreeResponse
            {
                ClientToken = clientToken
            };
        }

        public async Task<Transaction> CreateTransaction(BraintreeSaveRequest braintreeSaveRequest)
        {
            var gateway = _braintreeRepository.CreateGateway();

            var request = new TransactionRequest
            {
                Amount = braintreeSaveRequest.Amount,
                PaymentMethodNonce = _configuration["Braintree:Nonce"],
                Options = new TransactionOptionsRequest
                {
                    SubmitForSettlement = true
                }
            };
            
            var result = await gateway.Transaction.SaleAsync(request);
            
            if (result.IsSuccess())
                return result.Target;
            else
                foreach (var error in result.Errors.DeepAll())
                    _notification.AddNotification($"{error.Code}", EMessage.FillError.Description().FormatTo($"{error.Message}"));

            return null;
        }

        public async Task<Transaction> GetTransaction(string id)
        {
            var gateway = _braintreeRepository.CreateGateway();

            var transaction = await gateway.Transaction.FindAsync(id);
            
            if (transactionSuccessStatuses.Contains(transaction.Status))
                return transaction;
            else
                _notification.AddNotification("Transaction", EMessage.FailedTransaction.Description().FormatTo($"{transaction.Status}"));

            return null;
        }
    }
}
