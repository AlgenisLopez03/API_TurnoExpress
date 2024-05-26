using GestorDeTurnos.Application.Pagination;

namespace GestorDeTurnos.Application.Dtos.Review
{
    public class ReviewFilterAndPaginationDto : PaginationBase
    {
        public string? Establishment { get; set; }
    }
}