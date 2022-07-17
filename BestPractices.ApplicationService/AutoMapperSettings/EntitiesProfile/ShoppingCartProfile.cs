using AutoMapper;
using BestPractices.ApplicationService.Request.ShoppingCart;
using BestPractices.ApplicationService.Response.ShoppingCart;
using BestPractices.Domain.Entities;

namespace BestPractices.ApplicationService.AutoMapperSettings.EntitiesProfile
{
    public class ShoppingCartProfile : Profile
    {
        public ShoppingCartProfile()
        {
            CreateMap<ShoppingCart, ShoppingCartSaveRequest>()
                .ReverseMap();

            CreateMap<ShoppingCart, ShoppingCartUpdateRequest>()
                .ReverseMap();

            CreateMap<ShoppingCart, ShoppingCartResponse>()
                .ForMember(sr => sr.UserResponseClient, map => map.MapFrom(s => s.User))
                .ForMember(sr => sr.ProductsResponse, map => map.MapFrom(s => s.Products))
                .ReverseMap();
        }
    }
}
