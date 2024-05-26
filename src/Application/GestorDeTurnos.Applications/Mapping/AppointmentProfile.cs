using AutoMapper;
using GestorDeTurnos.Application.Dtos.Appointment;
using GestorDeTurnos.Domain.Entities;

namespace GestorDeTurnos.Application.Mapping
{
    public class AppointmentProfile : Profile
    {
        public AppointmentProfile()
        {
            CreateMap<CreateAppointmentDto, Appointment>();
            CreateMap<UpdateAppointmentDto, Appointment>();
            CreateMap<Appointment, AppointmentListDto>();
            CreateMap<Appointment, AppointmentDetailDto>();
        }
    }
}