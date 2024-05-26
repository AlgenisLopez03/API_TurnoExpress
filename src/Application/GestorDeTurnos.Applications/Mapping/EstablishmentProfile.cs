using AutoMapper;
using GestorDeTurnos.Application.Dtos.Establishment;
using GestorDeTurnos.Domain.Entities;

namespace GestorDeTurnos.Application.Mapping
{
    public class EstablishmentProfile : Profile
    {
        public EstablishmentProfile()
        {
            CreateMap<CreateEstablishmentDto, Establishment>();
            CreateMap<UpdateEstablishmentDto, Establishment>();
            CreateMap<Establishment, EstablishmentListDto>();
            CreateMap<Establishment, EstablishmentDetailDto>();
        }
    }
}