using BestPractices.ApplicationService.DTO_s.Request.Client;
using BestPractices.ApplicationService.DTO_s.Response;

namespace BestPractices.ApplicationService.Interfaces
{
    public interface IClientService
    {
        Task SaveAsync(ClientSaveRequest clientSaveRequest);
        Task UpdateAsync(ClientUpdateRequest clientUpdateRequest);
        Task DeleteAsync(int id);
        Task<ClientResponse> FindByIdAsync(int id);
        Task<List<ClientResponse>> FindAllPersonsAsync();
    }
}
