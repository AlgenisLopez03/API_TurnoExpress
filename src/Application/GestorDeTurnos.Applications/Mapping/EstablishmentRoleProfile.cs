
using AutoMapper;
using GestorDeTurnos.Application.Dtos.EstablishmentRole;
using GestorDeTurnos.Domain.Entities;

namespace GestorDeTurnos.Application.Mapping
{
    public class EstablishmentRoleProfile : Profile
    {
        public EstablishmentRoleProfile()
        {
            CreateMap<EstablishmentRoles, EstablishmentRoleDetailDto>();
            CreateMap<EstablishmentRoles, EstablishmentRoleListDto>();
        }
    }
}
