using GestorDeTurnos.Domain.Common;

namespace GestorDeTurnos.Domain.Entities
{
    public class EstablishmentTypes : EntityBase
    {
        public string TypeName {  get; set; }
        public ICollection<EstablishmentRoles>? EstablishmentRoles { get; set; }
    }
}
