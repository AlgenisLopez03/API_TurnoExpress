using Asp.Versioning;
using GestorDeTurnos.Application.Dtos.Employee;
using GestorDeTurnos.Application.Interfaces.Services;
using GestorDeTurnos.Application.Pagination;
using GestorDeTurnos.Application.Specification;
using GestorDeTurnos.Application.Wrappers;
using GestorDeTurnos.Domain.Entities;
using GestorDeTurnos.Persistence.DbContexts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GestorDeTurnos.API.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [Authorize]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(ApplicationDbContext context, IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        /// <summary>
        /// Retrieves all employees with pagination and filtering options.
        /// </summary>
        /// <param name="request">The filter and pagination parameters for retrieving employees.</param>
        /// <returns>An ApiResponse containing a paged collection of EmployeeListDto.</returns>
        [HttpGet]
        public async Task<ActionResult<ApiResponse<PagedCollection<EmployeeListDto>>>> GetAllEmployeesAsync([FromQuery] EmployeeFilterAndPaginationDto request)
        {
            var pagedEmployees = await _employeeService.GetAllProjectedWithPaginationAsync<EmployeeListDto, EmployeeSpecification>(request);
            var response = new ApiResponse<PagedCollection<EmployeeListDto>>(pagedEmployees);
            return Ok(response);
        }

        /// <summary>
        /// Retrieves the details of a specific employee based on its ID.
        /// </summary>
        /// <param name="id">The ID of the employee.</param>
        /// <returns>An ApiResponse containing the details of the employee as EmployeeDetailDto.</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<ApiResponse<EmployeeDetailDto>>> GetEmployee(int id)
        {
            var data = await _employeeService.GetByIdProjectedAsync<EmployeeDetailDto>(id);
            var response = new ApiResponse<EmployeeDetailDto?>(data);
            return Ok(response);
        }

        /// <summary>
        /// Updates a specific employee.
        /// </summary>
        /// <param name="id">The ID of the employee to update.</param>
        /// <param name="request">The updated employee data.</param>
        /// <returns>No content.</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployee(int id, UpdateEmployeeDto request)
        {
            await _employeeService.UpdateAsync(id, request);
            return NoContent();
        }

        /// <summary>
        /// Creates a new employee.
        /// </summary>
        /// <param name="employee">The data for the new employee.</param>
        /// <returns>A newly created employee.</returns>
        [HttpPost]
        public async Task<ActionResult> PostEmployee(CreateEmployeeDto employee)
        {
            var newEmployee = await _employeeService.CreateAsync(employee);
            var response = new ApiResponse<Employees>(newEmployee);
            return CreatedAtAction("GetEmployee", new { id = newEmployee.Id }, response);
        }

        /// <summary>
        /// Deletes a specific employee.
        /// </summary>
        /// <param name="id">The ID of the employee to delete.</param>
        /// <returns>No content.</returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteEmployee(int id)
        {
            await _employeeService.DeleteAsync(id);
            return NoContent();
        }
    }
}
