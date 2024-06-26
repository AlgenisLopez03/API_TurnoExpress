using GestorDeTurnos.Domain.Common;

namespace GestorDeTurnos.Domain.Entities
{
    public class Employees : EntityBase
    {
        public string UserId { get; set; }
        public int EstablishmentId { get; set; }
        public bool Availabe {  get; set; }

        public Establishment Establishment { get; set; }
        public ICollection<EstablishmentRoles>? EstablishmentRoles { get; set; }
        public ICollection<Service> Services { get; set; }
    }
}
