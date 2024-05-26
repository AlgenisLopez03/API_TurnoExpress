using GestorDeTurnos.Domain.Common;

namespace GestorDeTurnos.Domain.Entities
{
    public class Status: EntityBase
    {
        public string Name { get; set; }

        public ICollection<Appointment> Appointments { get; set; }
    }
}