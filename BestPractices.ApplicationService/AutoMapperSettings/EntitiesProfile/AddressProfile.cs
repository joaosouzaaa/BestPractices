using AutoMapper;
using BestPractices.ApplicationService.Response.Address;
using BestPractices.Domain.Entities;

namespace BestPractices.ApplicationService.AutoMapperSettings.EntitiesProfile
{
    public class AddressProfile : Profile
    {
        public AddressProfile()
        {
            CreateMap<Address, AddressResponse>()
                .ReverseMap();
        }
    }
}
