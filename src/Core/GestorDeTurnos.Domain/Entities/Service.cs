namespace GestorDeTurnos.Domain.Entities
{
    using GestorDeTurnos.Domain.Common;
    using System.Collections.Generic;

    public class Service : EntityBase
    {
        public int EstablishmentId { get; set; }
        public string ServiceName { get; set; }
        public string ServiceImage { get; set; }
        public int Duration { get; set; }
        public decimal Price { get; set; }

        public Establishment Establishment { get; set; }
        public ICollection<Appointment> Appointments { get; set; }
        public ICollection<Employees> Employees { get; set; }

    }
}