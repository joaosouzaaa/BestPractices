using BestPractices.ApplicationService.AutoMapperSettings;
using BestPractices.ApplicationService.DTO_s.Request.Client;
using BestPractices.ApplicationService.DTO_s.Response;
using BestPractices.ApplicationService.Interfaces;
using BestPractices.ApplicationService.Services.ServiceBase;
using BestPractices.Business.Extensions;
using BestPractices.Business.Interfaces.Notification;
using BestPractices.Business.Interfaces.Repository;
using BestPractices.Business.Interfaces.Validation;
using BestPractices.Business.Settings.PaginationSettings;
using BestPractices.Domain.Entities;
using BestPractices.Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace BestPractices.ApplicationService.Services
{
    public class ClientService : BaseService<Client>, IClientService
    {
        private readonly IClientRepository _clientRepository;

        public ClientService(IClientRepository clientRepository,
            IValidate<Client> validate, INotificationHandler notification) 
            : base(validate, notification)
        {
            _clientRepository = clientRepository;
        }

        public async Task<bool> SaveAsync(ClientSaveRequest clientSaveRequest)
        {
            var client = clientSaveRequest.MapTo<ClientSaveRequest, Client>();

            if (!await ValidatedAsync(client))
                return false;
            else
                return await _clientRepository.SaveAsync(client);
        }

        public async Task<bool> UpdateAsync(ClientUpdateRequest clientUpdateRequest)
        {
            var client = clientUpdateRequest.MapTo<ClientUpdateRequest, Client>();

            if (!await ValidatedAsync(client))
                return false;

            return await _clientRepository.UpdateAsync(client);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            if (!await _clientRepository.EntityExistAsync(id))
                _notification.AddNotification($"{id}", EMessage.NotFound.Description().FormatTo($"{id}"));

            return await _clientRepository.DeleteAsync(id);
        }        

        public async Task<ClientResponse> FindByIdAsync(int id)
        {
            if (!await _clientRepository.EntityExistAsync(id))
                _notification.AddNotification($"{id}", EMessage.NotFound.Description().FormatTo($"{id}"));

            var client = await _clientRepository.GetById(id);

            return client.MapTo<Client, ClientResponse>();
        }

        public async Task<List<ClientResponse>> FindAllEntitiesAsync()
        {
            var clients = await _clientRepository.GetAll();

            return clients.MapTo<List<Client>, List<ClientResponse>>();
        }

        public async Task<PageList<ClientResponse>> FindAllEntitiesWithPaginationAsync(PageParams pageParams)
        {
            var clients = await _clientRepository.FindAllWithPaginationIncludeEntities(pageParams);

            return clients.MapTo<PageList<Client>, PageList<ClientResponse>>();
        }
    }
}
