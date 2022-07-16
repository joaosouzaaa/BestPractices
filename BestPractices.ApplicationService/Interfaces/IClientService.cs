using BestPractices.ApplicationService.DTO_s.Request.Client;
using BestPractices.ApplicationService.DTO_s.Response;
using BestPractices.ApplicationService.Interfaces.BaseService;

namespace BestPractices.ApplicationService.Interfaces
{
    public interface IClientService : IBaseQueryService<ClientSaveRequest, ClientUpdateRequest, ClientResponse>
    {

    }
}
