using AutoMapper;
using BestPractices.ApplicationService.Request.Supplier;
using BestPractices.ApplicationService.Response.Supplier;
using BestPractices.Business.Settings.PaginationSettings;
using BestPractices.Domain.Entities;

namespace BestPractices.ApplicationService.AutoMapperSettings.EntitiesProfile
{
    public class SupplierProfile : Profile
    {
        public SupplierProfile()
        {
            CreateMap<Supplier, SupplierSaveRequest>()
                   .ForMember(ss => ss.CompanyAddress, map => map.MapFrom(s => s.CompanyAddress))
                   .ReverseMap();

            CreateMap<Supplier, SupplierUpdateRequest>()
                   .ForMember(ss => ss.CompanyAddress, map => map.MapFrom(s => s.CompanyAddress))
                   .ReverseMap();

            CreateMap<Supplier, SupplierResponse>()
                .ForMember(sr => sr.CompanyAddressResponse, map => map.MapFrom(s => s.CompanyAddress))
                .ForMember(sr => sr.ProductsResponse, map => map.MapFrom(s => s.Products))
                .ReverseMap();

            CreateMap<PageList<Supplier>, PageList<SupplierResponse>>()
                .ReverseMap();
        }
    }
}
