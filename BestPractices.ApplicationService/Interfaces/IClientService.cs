using BestPractices.ApplicationService.Interfaces.BaseService;
using BestPractices.ApplicationService.Request.Client;
using BestPractices.ApplicationService.Response.Client;

namespace BestPractices.ApplicationService.Interfaces
{
    public interface IClientService : IBaseQueryService<ClientSaveRequest, ClientUpdateRequest, ClientResponse>
    {

    }
}
