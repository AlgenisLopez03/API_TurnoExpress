using Asp.Versioning;
using GestorDeTurnos.Application.Dtos.JobApplication;
using GestorDeTurnos.Application.Interfaces.Services;
using GestorDeTurnos.Application.Pagination;
using GestorDeTurnos.Application.Specification;
using GestorDeTurnos.Application.Wrappers;
using GestorDeTurnos.Domain.Entities;
using GestorDeTurnos.Persistence.DbContexts;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GestorDeTurnos.API.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class JobApplicationController : ControllerBase
    {
        private readonly IJobApplicationService _jobApplicationService;

        public JobApplicationController(ApplicationDbContext context, IJobApplicationService jobApplicationService)
        {
            _jobApplicationService = jobApplicationService;
        }

        /// <summary>
        /// Retrieves all job applications with pagination and filtering options.
        /// </summary>
        /// <param name="request">The filter and pagination parameters for retrieving job applications.</param>
        /// <returns>An ApiResponse containing a paged collection of JobApplicationListDto.</returns>
        [HttpGet]
        public async Task<ActionResult<ApiResponse<PagedCollection<JobApplicationListDto>>>> GetAllJobApplicationsAsync([FromQuery] JobApplicationFilterAndPaginationDto request)
        {
            var pagedJobApplications = await _jobApplicationService.GetAllProjectedWithPaginationAsync<JobApplicationListDto, JobApplicationSpecification>(request);
            var response = new ApiResponse<PagedCollection<JobApplicationListDto>>(pagedJobApplications);
            return Ok(response);
        }

        /// <summary>
        /// Retrieves the details of a specific job application based on its ID.
        /// </summary>
        /// <param name="id">The ID of the job application.</param>
        /// <returns>An ApiResponse containing the details of the job application as JobApplicationDetailDto.</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<ApiResponse<JobApplicationDetailDto>>> GetJobApplication(int id)
        {
            var data = await _jobApplicationService.GetByIdProjectedWithIncludesAsync<JobApplicationDetailDto>(id, j => j.Establishment, j => j.Role);
            var response = new ApiResponse<JobApplicationDetailDto?>(data);
            return Ok(response);
        }

        /// <summary>
        /// Updates a specific job application.
        /// </summary>
        /// <param name="id">The ID of the job application to update.</param>
        /// <param name="request">The updated job application data.</param>
        /// <returns>No content.</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutJobApplication(int id, UpdateJobApplicationDto request)
        {
            await _jobApplicationService.UpdateAsync(id, request);
            return NoContent();
        }

        /// <summary>
        /// Creates a new job application.
        /// </summary>
        /// <param name="jobApplication">The data for the new job application.</param>
        /// <returns>A newly created job application.</returns>
        [HttpPost]
        public async Task<ActionResult> PostJobApplication(CreateJobApplicationDto jobApplication)
        {
            var newJobApplication = await _jobApplicationService.CreateAsync(jobApplication);
            var response = new ApiResponse<JobApplication>(newJobApplication);
            return CreatedAtAction("GetJobApplication", new { id = newJobApplication.Id }, response);
        }

        /// <summary>
        /// Deletes a specific job application.
        /// </summary>
        /// <param name="id">The ID of the job application to delete.</param>
        /// <returns>No content.</returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteJobApplication(int id)
        {
            await _jobApplicationService.DeleteAsync(id);
            return NoContent();
        }
    }
}
