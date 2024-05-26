using GestorDeTurnos.Domain.Common;

namespace GestorDeTurnos.Domain.Entities
{
    public class Report : EntityBase
    {
        public int EstablishmentId { get; set; }
        public DateTime Date { get; set; }
        public decimal Revenue { get; set; }
        public int AppointmentsCount { get; set; }

        public Establishment Establishment { get; set; }
    }
}