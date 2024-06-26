using GestorDeTurnos.Domain.Common;

namespace GestorDeTurnos.Domain.Entities
{
    public class EstablishmentRoles : EntityBase
    {
        public int EstablishmentTypeId { get; set; }
        public string RoleName { get; set; }

        public EstablishmentTypes EstablishmentType { get; set; }
        public ICollection<Employees>? Employees { get; set; }
    }
}
