
using GestorDeTurnos.Application.Pagination;

namespace GestorDeTurnos.Application.Dtos.EstablishmentRole
{
    public class EstablishmentRoleFilterAndPaginationDto : PaginationBase
    {
        public int? EstablishmentTypeId { get; set; }

        public string? EstablishmentType { get; set; }
    }
}
