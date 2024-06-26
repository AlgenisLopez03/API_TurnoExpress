
using GestorDeTurnos.Domain.Common;

namespace GestorDeTurnos.Domain.Entities
{
    public class JobApplication : EntityBase
    {
        public string UserId { get; set; }
        public int EstablishmentId { get; set; }
        public int RoleId { get; set; }
        public string Status { get; set; }

        public Establishment Establishment { get; set; }
        public EstablishmentRoles Role { get; set; }
    }
}
