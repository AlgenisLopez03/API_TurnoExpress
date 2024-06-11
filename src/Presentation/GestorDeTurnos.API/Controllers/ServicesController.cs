using Asp.Versioning;
using GestorDeTurnos.Application.Dtos.Service;
using GestorDeTurnos.Application.Helpers;
using GestorDeTurnos.Application.Interfaces.Helpers;
using GestorDeTurnos.Application.Interfaces.Services;
using GestorDeTurnos.Application.Pagination;
using GestorDeTurnos.Application.Specification;
using GestorDeTurnos.Application.Wrappers;
using GestorDeTurnos.Domain.Entities;
using GestorDeTurnos.Persistence.DbContexts;
using Microsoft.AspNetCore.Mvc;

namespace GestorDeTurnos.API.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class ServicesController : ControllerBase
    {
        private readonly IServiceService _serviceService;
        private readonly IFileManager<Service> _fileManager;

        public ServicesController(ApplicationDbContext context, IServiceService serviceService, IFileManager<Service> fileManager)
        {
            _serviceService = serviceService;
            _fileManager = fileManager;
        }

        [HttpGet]
        public async Task<ActionResult<ApiResponse<PagedCollection<ServiceListDto>>>> GetAllServicesAsync([FromQuery] ServiceFilterAndPaginationDto request)
        {
            var pagedServices = await _serviceService.GetAllProjectedWithPaginationAsync<ServiceListDto, ServiceSpecification>(request);
            var response = new ApiResponse<PagedCollection<ServiceListDto>>(pagedServices);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ApiResponse<ServiceDetailDto>>> GetService(int id)
        {
            var data = await _serviceService.GetByIdProjectedAsync<ServiceDetailDto>(id);
            var response = new ApiResponse<ServiceDetailDto?>(data);
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult> PostService(CreateServiceDto service)
        {
            var imageName = string.Empty;

            if (service.ImageFile != null)
            {
                imageName = await _fileManager.SaveAsync(service.ImageFile);
            }

            service.ServiceImage = imageName;

            var newService = await _serviceService.CreateAsync(service);
            var response = new ApiResponse<Service>(newService);
            return CreatedAtAction("GetService", new { id = newService.Id }, response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutService(int id, [FromForm] UpdateServiceDto request)
        {
            if (request.ImageFile != null)
            {
                request.ServiceImage = await _fileManager.UpdateAsync(request.ImageFile, request.ServiceImage);
            }
            await _serviceService.UpdateAsync(id, request);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteService(int id)
        {
            var service = await _serviceService.GetByIdAsync(id);
            _fileManager.Delete(service.ServiceImage);

            await _serviceService.DeleteAsync(id);
            return NoContent();
        }
    }
}