using GestorDeTurnos.Domain.Entities;

namespace GestorDeTurnos.Application.Interfaces.Repositories
{
    public interface IAppointmentRepository : IAsyncRepository<Appointment>
    {
    }
}