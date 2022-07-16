using AutoMapper;
using BestPractices.ApplicationService.DTO_s.Request.Client;
using BestPractices.ApplicationService.DTO_s.Response;
using BestPractices.Business.Settings.PaginationSettings;
using BestPractices.Domain.Entities;

namespace BestPractices.ApplicationService.AutoMapperSettings.EntitiesProfile
{
    public class ClientProfile : Profile
    {
        public ClientProfile()
        {
            CreateMap<Client, ClientSaveRequest>()
                .ReverseMap();

            CreateMap<Client, ClientUpdateRequest>()
                .ReverseMap();

            CreateMap<Client, ClientResponse>()
                .ReverseMap();

            CreateMap<PageList<Client>, PageList<ClientResponse>>()
                .ReverseMap();
        }
    }
}
