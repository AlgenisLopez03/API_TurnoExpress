using Asp.Versioning;
using GestorDeTurnos.Application.Dtos.Appointment;
using GestorDeTurnos.Application.Interfaces.Services;
using GestorDeTurnos.Application.Pagination;
using GestorDeTurnos.Application.Specification;
using GestorDeTurnos.Application.Wrappers;
using GestorDeTurnos.Domain.Entities;
using GestorDeTurnos.Persistence.DbContexts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GestorDeTurnos.API.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [Authorize]
    public class AppointmentsController : ControllerBase
    {
        private readonly IAppointmentService _appointmentService;

        public AppointmentsController(ApplicationDbContext context, IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }

        [HttpGet]
        public async Task<ActionResult<ApiResponse<PagedCollection<AppointmentListDto>>>> GetAllAppointmentsAsync([FromQuery] AppointmentFilterAndPaginationDto request)
        {
            var pagedAppointments = await _appointmentService.GetAllProjectedWithPaginationAsync<AppointmentListDto, AppointmentSpecification>(request);
            var response = new ApiResponse<PagedCollection<AppointmentListDto>>(pagedAppointments);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ApiResponse<AppointmentDetailDto>>> GetAppointment(int id)
        {
            var data = await _appointmentService.GetByIdProjectedWithIncludesAsync<AppointmentDetailDto>(id, a => a.Status, a => a.Employee, a => a.Establishment, a => a.Service);

            var response = new ApiResponse<AppointmentDetailDto?>(data);
            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAppointment(int id, UpdateAppointmentDto request)
        {
            await _appointmentService.UpdateAsync(id, request);
            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult> PostAppointment(CreateAppointmentDto appointment)
        {
            var newAppointment = await _appointmentService.CreateAsync(appointment);
            var response = new ApiResponse<Appointment>(newAppointment);
            return CreatedAtAction("GetAppointment", new { id = newAppointment.Id }, response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAppointment(int id)
        {
            await _appointmentService.DeleteAsync(id);
            return NoContent();
        }
    }
}