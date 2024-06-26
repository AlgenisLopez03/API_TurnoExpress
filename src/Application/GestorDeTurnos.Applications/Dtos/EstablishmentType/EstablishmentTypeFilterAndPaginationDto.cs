
using GestorDeTurnos.Application.Pagination;

namespace GestorDeTurnos.Application.Dtos.EstablishmentType
{
    public class EstablishmentTypeFilterAndPaginationDto : PaginationBase
    {
        public string? TypeName { get; set; }
    }
}
