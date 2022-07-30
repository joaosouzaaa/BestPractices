using AutoMapper;
using BestPractices.ApplicationService.Request.Product;
using BestPractices.ApplicationService.Response.Product;
using BestPractices.Business.Settings.PaginationSettings;
using BestPractices.Domain.Entities;

namespace BestPractices.ApplicationService.AutoMapperSettings.EntitiesProfile
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductSaveRequest>()
                .ForMember(ps => ps.Category, map => map.MapFrom(p => p.Category))
                .ReverseMap();
            
            CreateMap<Product, ProductUpdateRequest>()
                .ForMember(pu => pu.Category, map => map.MapFrom(p => p.Category))
                .ReverseMap();

            CreateMap<Product, ProductResponse>()
                .ForMember(pr => pr.FileImageResponse, map => map.MapFrom(p => p.FileImage))
                .ForMember(pr => pr.SupplierResponse, map => map.MapFrom(p => p.Supplier))
                .ReverseMap();

            CreateMap<PageList<Product>, PageList<ProductResponse>>()
                .ReverseMap();
        }
    }
}
