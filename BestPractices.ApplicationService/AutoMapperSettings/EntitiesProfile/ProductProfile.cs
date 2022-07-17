using AutoMapper;
using BestPractices.ApplicationService.Response.Product;
using BestPractices.Domain.Entities;

namespace BestPractices.ApplicationService.AutoMapperSettings.EntitiesProfile
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductResponse>()
                .ForMember(pr => pr.FileImageResponse, map => map.MapFrom(p => p.FileImage))
                .ForMember(pr => pr.SupplierResponse, map => map.MapFrom(p => p.Supplier))
                .ReverseMap();
        }
    }
}
