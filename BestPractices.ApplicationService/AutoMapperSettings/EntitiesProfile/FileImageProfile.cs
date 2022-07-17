using AutoMapper;
using BestPractices.ApplicationService.Response.FileImage;
using BestPractices.Domain.Entities;

namespace BestPractices.ApplicationService.AutoMapperSettings.EntitiesProfile
{
    public class FileImageProfile : Profile
    {
        public FileImageProfile()
        {
            CreateMap<FileImage, FileImageResponse>()
                .ReverseMap();
        }
    }
}
