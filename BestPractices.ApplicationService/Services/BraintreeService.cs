using BestPractices.ApplicationService.DTO_s.Request.Braintree;
using BestPractices.ApplicationService.DTO_s.Response.Braintree;
using BestPractices.ApplicationService.Interfaces;
using BestPractices.ApplicationService.Services.ServiceBase;
using BestPractices.Business.Interfaces.Notification;
using BestPractices.Business.Interfaces.Repository;
using BestPractices.Business.Interfaces.Validation;
using BestPractices.Domain.Enums;
using BestPractices.Domain.Extensions;
using Braintree;
using Microsoft.Extensions.Configuration;

namespace BestPractices.ApplicationService.Services
{
    public class BraintreeService : BaseService, IBraintreeService
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

        public BraintreeService(IValidationHandler validationHandler, INotificationHandler notificationHandler, IBraintreeRepository braintreeRepository, IConfiguration configuration)
            : base(validationHandler, notificationHandler)
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

        public Transaction CreateTransaction(BraintreeSaveRequest braintreeSaveRequest)
        {
            string nonceFromTheClient = _configuration["Braintree:Nonce"] ;

            var gateway = _braintreeRepository.CreateGateway();

            var request = new TransactionRequest
            {
                Amount = braintreeSaveRequest.Amount,
                PaymentMethodNonce = nonceFromTheClient,
                Options = new TransactionOptionsRequest
                {
                    SubmitForSettlement = true
                }
            };

            var result = gateway.Transaction.Sale(request);
            
            if (result.IsSuccess())
            {
                var transaction = result.Target;
                return transaction;

            }
            else
            {
                foreach (var error in result.Errors.DeepAll())
                {
                    _notificationHandler.AddNotification($"{error.Code}", EMessage.FillError.Description().FormatTo($"{error.Message}"));
                }
            }

            return null;
        }

        public async Task<Transaction> GetTransaction(string id)
        {
            var gateway = _braintreeRepository.CreateGateway();

            var transaction = await gateway.Transaction.FindAsync(id);
            
            if (transactionSuccessStatuses.Contains(transaction.Status))
            {
                return transaction;
            }
            else
            {
                _notificationHandler.AddNotification("Transaction", EMessage.FailedTransaction.Description().FormatTo($"{transaction.Status}"));
            };

            return null;
        }
    }
}
