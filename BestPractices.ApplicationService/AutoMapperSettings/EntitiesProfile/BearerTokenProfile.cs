using AutoMapper;
using BestPractices.ApplicationService.Response.BearerToken;
using BestPractices.Domain.Entities;

namespace BestPractices.ApplicationService.AutoMapperSettings.EntitiesProfile
{
    public class BearerTokenProfile : Profile
    {
        public BearerTokenProfile()
        {
            CreateMap<BearerToken, BearerTokenResponse>();
        }
    }
}
