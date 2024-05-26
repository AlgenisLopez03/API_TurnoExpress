using GestorDeTurnos.Domain.Common;

namespace GestorDeTurnos.Domain.Entities
{
    public class Appointment : EntityBase
    {
        public string UserId { get; set; }
        public int EstablishmentId { get; set; }
        public int ServiceId { get; set; }
        public int StatusId { get; set; }
        public DateTime Date { get; set; }

        public int Position { get; set; }
        public Status Status { get; set; }
        public Establishment? Establishment { get; set; }
        public Service? Service { get; set; }
    }
}