using BestPractices.ApplicationService.DTO_s.Request.Braintree;
using BestPractices.ApplicationService.DTO_s.Response.Braintree;
using BestPractices.ApplicationService.Interfaces;
using BestPractices.Business.NotificationSettings;
using Braintree;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BestPractices.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BraintreeController : ControllerBase
    {
        private readonly IBraintreeService _braintreeService;

        public BraintreeController(IBraintreeService braintreeService)
        {
            _braintreeService = braintreeService;
        }

        [HttpPost("generate-token")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(IEnumerable<DomainNotification>))]
        public async Task<BraintreeResponse> GetClientToken()
        {
            return await _braintreeService.GenerateClientToken();
        }

        [HttpPost("create-transaction")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(IEnumerable<DomainNotification>))]
        public Transaction CreateTransaction(BraintreeSaveRequest braintreeSaveRequest)
        {
            return _braintreeService.CreateTransaction(braintreeSaveRequest);
        }

        [HttpGet("find-transaction")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(IEnumerable<DomainNotification>))]
        public async Task<Transaction> FindTransaction(string id)
        {
            return await _braintreeService.GetTransaction(id);
        }
    }
}
