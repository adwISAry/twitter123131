using AutoMapper;
using TwitterClone.Business.Dtos.AuthDtos;
using TwitterClone.Core.Entities;

namespace TwitterClone.Business.Profiles
{
    public class AppUserMappingProfile : Profile
    {
        public AppUserMappingProfile()
        {
            CreateMap<RegisterDto, AppUser>();
        }
    }
}
