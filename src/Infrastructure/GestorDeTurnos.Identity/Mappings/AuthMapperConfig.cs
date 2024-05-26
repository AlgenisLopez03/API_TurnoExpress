using AutoMapper;
using GestorDeTurnos.Application.Dtos.User;
using GestorDeTurnos.Identity.Models;

namespace GestorDeTurnos.Identity.Mappings
{
    public class AuthMapperConfig : Profile
    {
        public AuthMapperConfig()
        {
            CreateMap<UserCreateRequest, CustomIdentityUser>().ReverseMap();
        }
    }
}