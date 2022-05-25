using BestPractices.ApplicationService.DTO_s.Request.Braintree;
using BestPractices.ApplicationService.DTO_s.Response.Braintree;
using BestPractices.ApplicationService.Interfaces;
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
        public async Task<BraintreeResponse> GetClientToken()
        {
            return await _braintreeService.GenerateClientToken();
        }

        [HttpPost("create-transaction")]
        public Transaction CreateTransaction(BraintreeSaveRequest braintreeSaveRequest)
        {
            return _braintreeService.CreateTransaction(braintreeSaveRequest);
        }

        [HttpGet("find-transaction")]
        public Transaction FindTransaction(string id)
        {
            return _braintreeService.GetTransaction(id);
        }
    }
}
