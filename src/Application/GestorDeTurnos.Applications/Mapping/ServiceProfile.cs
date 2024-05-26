using AutoMapper;
using GestorDeTurnos.Application.Dtos.Service;
using GestorDeTurnos.Domain.Entities;

namespace GestorDeTurnos.Application.Mapping
{
    public class ServiceProfile : Profile
    {
        public ServiceProfile()
        {
            CreateMap<CreateServiceDto, Service>();
            CreateMap<UpdateServiceDto, Service>();
            CreateMap<Service, ServiceListDto>();
            CreateMap<Service, ServiceDetailDto>();
        }
    }
}