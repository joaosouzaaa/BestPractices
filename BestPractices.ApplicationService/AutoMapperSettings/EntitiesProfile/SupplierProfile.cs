using AutoMapper;
using BestPractices.ApplicationService.Response.Supplier;
using BestPractices.Domain.Entities;

namespace BestPractices.ApplicationService.AutoMapperSettings.EntitiesProfile
{
    public class SupplierProfile : Profile
    {
        public SupplierProfile()
        {
            CreateMap<Supplier, SupplierResponse>()
                .ForMember(sr => sr.CompanyAddressResponse, map => map.MapFrom(s => s.CompanyAddress))
                .ForMember(sr => sr.ProductsResponse, map => map.MapFrom(s => s.Products))
                .ReverseMap();
        }
    }
}
