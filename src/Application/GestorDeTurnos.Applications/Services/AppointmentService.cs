using AutoMapper;
using GestorDeTurnos.Application.Interfaces.Repositories;
using GestorDeTurnos.Application.Interfaces.Services;
using GestorDeTurnos.Domain.Entities;
using Microsoft.AspNetCore.Http;

namespace GestorDeTurnos.Application.Services
{
    public class AppointmentService : ServiceBase<Appointment>, IAppointmentService
    {
        private readonly IMapper _mapper;
        public AppointmentService(IAsyncRepository<Appointment> repository, IMapper mapper, IHttpContextAccessor httpContext) : base(repository, mapper, httpContext)
        {
            _mapper = mapper;

        }
        public override async Task<Appointment> CreateAsync<TSource>(TSource source)
        {
            var appointment = _mapper.Map<Appointment>(source);

            appointment.Date = DateTime.Now;

            var existingAppointments = await repository.ListAsync(
                a => a.EstablishmentId == appointment.EstablishmentId && a.Date.Date == appointment.Date.Date);

            if (existingAppointments.Any())
            {
                appointment.Position = existingAppointments.Max(a => a.Position) + 1;
            }
            else
            {
                appointment.Position = 1;
            }

            await repository.CreateAsync(appointment);
            return appointment;
        }
    }
}