using BestPractices.ApplicationService.DTO_s.Request.Client;
using BestPractices.ApplicationService.DTO_s.Response;
using BestPractices.ApplicationService.Interfaces;
using BestPractices.Business.NotificationSettings;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BestPractices.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _clientService;

        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
        }

        [HttpPost("post")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(IEnumerable<DomainNotification>))]
        public async Task Post(ClientSaveRequest clientSaveRequest)
        {
            await this._clientService.SaveAsync(clientSaveRequest);
        }

        [HttpPut("put")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(IEnumerable<DomainNotification>))]
        public async Task Put(ClientUpdateRequest clientUpdateRequest)
        {
            await this._clientService.UpdateAsync(clientUpdateRequest);
        }

        [HttpDelete("delete/{id:int}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(IEnumerable<DomainNotification>))]
        public async Task Delete(int id)
        {
            await this._clientService.DeleteAsync(id);
        }

        [HttpGet("get/{id:int}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(IEnumerable<DomainNotification>))]
        public async Task<ClientResponse> Get(int id)
        {
            return await this._clientService.FindByIdAsync(id);
        }

        [HttpGet("get")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(IEnumerable<DomainNotification>))]
        public async Task<List<ClientResponse>> Get()
        {
            return await this._clientService.FindAllPersonsAsync();
        }
    }
}
