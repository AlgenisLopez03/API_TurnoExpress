using GestorDeTurnos.Application.Pagination;

namespace GestorDeTurnos.Application.Dtos.Service
{
    public class ServiceFilterAndPaginationDto : PaginationBase
    {
        public string? Service { get; set; }
        public string? Establishment { get; set; }
    }
}