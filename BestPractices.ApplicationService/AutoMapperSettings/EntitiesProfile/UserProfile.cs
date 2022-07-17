using AutoMapper;
using BestPractices.ApplicationService.Request.User;
using BestPractices.ApplicationService.Response.User;
using BestPractices.Business.Settings.PaginationSettings;
using BestPractices.Domain.Entities;

namespace BestPractices.ApplicationService.AutoMapperSettings.EntitiesProfile
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserSaveRequest>()
                .ForMember(usr => usr.Email, map => map.MapFrom(u => u.Email))
                .ForMember(usr => usr.Password, map => map.MapFrom(u => u.PasswordHash))
                .ReverseMap();

            CreateMap<User, UserResponse>()
                .ForMember(ur => ur.Email, map => map.MapFrom(u => u.Email))
                .ForMember(ur => ur.Password, map => map.MapFrom(u => u.PasswordHash))
                .ReverseMap();

            CreateMap<User, UserResponseClient>()
                .ForMember(urc => urc.ClientResponse, map => map.MapFrom(u => u.Client))
                .ReverseMap();

            CreateMap<PageList<User>, PageList<UserResponseClient>>()
                .ReverseMap();
        }
    }
}
