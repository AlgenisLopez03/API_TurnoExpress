
using AutoMapper;
using GestorDeTurnos.Application.Dtos.Status;
using GestorDeTurnos.Domain.Entities;

namespace GestorDeTurnos.Application.Mapping
{
    public class StatusProfile : Profile
    {
        public StatusProfile() 
        {
            CreateMap<Status, StatusDetailDto>();
        }
    }
}
