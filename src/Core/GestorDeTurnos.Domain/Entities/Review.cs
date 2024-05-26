using GestorDeTurnos.Domain.Common;

namespace GestorDeTurnos.Domain.Entities
{
    public class Review : EntityBase
    {
        public string UserId { get; set; }
        public int EstablishmentId { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
        public DateTime Date { get; set; }

        public Establishment Establishment { get; set; }
    }
}