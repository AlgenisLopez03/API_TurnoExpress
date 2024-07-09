using GestorDeTurnos.Application.Enums;
using GestorDeTurnos.Application.Pagination;

namespace GestorDeTurnos.Application.Dtos.Appointment
{
    public class AppointmentFilterAndPaginationDto : PaginationBase
    {
        public string? UserId {  get; set; }
        public int? EmployeeId { get; set; }
        public int? ServiceId { get; set; }
        public int? EstablishmentId { get; set; }
        public StatusType? Status { get; set; }
    }
}