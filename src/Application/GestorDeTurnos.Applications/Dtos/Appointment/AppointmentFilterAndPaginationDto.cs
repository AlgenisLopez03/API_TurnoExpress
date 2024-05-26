using GestorDeTurnos.Application.Pagination;

namespace GestorDeTurnos.Application.Dtos.Appointment
{
    public class AppointmentFilterAndPaginationDto : PaginationBase
    {
        public string? Service { get; set; }
        public string? Establishment { get; set; }
    }
}