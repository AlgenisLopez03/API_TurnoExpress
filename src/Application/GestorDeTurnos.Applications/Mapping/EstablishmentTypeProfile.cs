
using AutoMapper;
using GestorDeTurnos.Application.Dtos.EstablishmentType;
using GestorDeTurnos.Domain.Entities;

namespace GestorDeTurnos.Application.Mapping
{
    public class EstablishmentTypeProfile : Profile
    {
        public EstablishmentTypeProfile()
        {
            CreateMap<EstablishmentTypes, EstablishmentTypeDetailDto>();
            CreateMap<EstablishmentTypes, EstablishmentTypeListDto>();
        }
    }
}
