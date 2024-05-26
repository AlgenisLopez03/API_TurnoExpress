using GestorDeTurnos.Domain.Entities;

namespace GestorDeTurnos.Application.Interfaces.Services
{
    public interface IAppointmentService : IAsyncService<Appointment>
    {
    }
}