using BestPractices.ApplicationService.AutoMapperSettings;
using BestPractices.ApplicationService.DTO_s.Request.Client;
using BestPractices.ApplicationService.DTO_s.Response;
using BestPractices.ApplicationService.Interfaces;
using BestPractices.ApplicationService.Services.ServiceBase;
using BestPractices.Business.Interfaces.Notification;
using BestPractices.Business.Interfaces.Repository;
using BestPractices.Business.Interfaces.Validation;
using BestPractices.Domain.Entities;
using BestPractices.Domain.EntitiesValidation;
using BestPractices.Domain.Enums;
using BestPractices.Domain.Extensions;

namespace BestPractices.ApplicationService.Services
{
    public class ClientService : BaseService, IClientService
    {
        private readonly IClientRepository _clientRepository;

        public ClientService(IValidationHandler validationHandler, INotificationHandler notificationHandler, IClientRepository clientRepository) 
            : base(validationHandler, notificationHandler)
        {
            _clientRepository = clientRepository;
        }

        public async Task SaveAsync(ClientSaveRequest clientSaveRequest)
        {
            var client = clientSaveRequest.MapTo<ClientSaveRequest, Client>();

            if (await this.ValidatedAsync(client, new ClientValidation()))
            {
                await this._clientRepository.Save(client);
            }
        }

        public async Task UpdateAsync(ClientUpdateRequest clientUpdateRequest)
        {
            var client = clientUpdateRequest.MapTo<ClientUpdateRequest, Client>();

            if (await this.ValidatedAsync(client, new ClientValidation()))
            {
                await this._clientRepository.Update(client);
            }
        }

        public async Task DeleteAsync(int id)
        {
            if (!_clientRepository.EntityExist(id))
                this._notificationHandler.AddNotification($"{id}", EMessage.NotFound.Description().FormatTo($"{id}"));

            await this._clientRepository.Delete(id);
        }        

        public async Task<ClientResponse> FindByIdAsync(int id)
        {
            if (!_clientRepository.EntityExist(id))
                this._notificationHandler.AddNotification($"{id}", EMessage.NotFound.Description().FormatTo($"{id}"));

            var client = await this._clientRepository.GetEntity(id);

            var clientResponse = client.MapTo<Client, ClientResponse>();

            return clientResponse;
        }

        public async Task<IEnumerable<ClientResponse>> FindAllEntitiesAsync()
        {
            var clients = await this._clientRepository.GetAllEntities();

            var clientsResponse = clients.MapTo<IEnumerable<Client>, IEnumerable<ClientResponse>>();

            return clientsResponse;
        }
    }
}
