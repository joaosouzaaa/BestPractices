using BestPractices.ApplicationService.Interfaces;
using BestPractices.ApplicationService.Request.Braintree;
using BestPractices.ApplicationService.Response.Braintree;
using BestPractices.Business.Settings.NotificationSettings;
using Braintree;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BestPractices.Api.Controllers
{
    [Authorize(AuthenticationSchemes = "Bearer")]
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
        public async Task<BraintreeResponse> GetClientToken() =>
            await _braintreeService.GenerateClientToken();

        [HttpPost("create-transaction")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(IEnumerable<DomainNotification>))]
        public Transaction CreateTransaction(BraintreeSaveRequest braintreeSaveRequest) =>
            _braintreeService.CreateTransaction(braintreeSaveRequest);

        [HttpGet("find-transaction")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(IEnumerable<DomainNotification>))]
        public async Task<Transaction> FindTransaction(string id) =>
            await _braintreeService.GetTransaction(id);
    }
}
