using AutoMapper;
using BestPractices.ApplicationService.Request.Address;
using BestPractices.ApplicationService.Response.Address;
using BestPractices.Domain.Entities;

namespace BestPractices.ApplicationService.AutoMapperSettings.EntitiesProfile
{
    public class AddressProfile : Profile
    {
        public AddressProfile()
        {
            CreateMap<Address, AddressSaveRequest>()
                .ReverseMap();

            CreateMap<Address, AddressUpdateRequest>()
                .ReverseMap();

            CreateMap<Address, AddressResponse>()
                .ReverseMap();
        }
    }
}
