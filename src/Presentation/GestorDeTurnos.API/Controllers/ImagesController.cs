using Asp.Versioning;
using GestorDeTurnos.Application.Constants;
using Microsoft.AspNetCore.Mvc;

namespace GestorDeTurnos.API.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private readonly string _root = Path.Combine(Directory.GetCurrentDirectory(), Paths.Uploads);

        [HttpGet("{folderName, imageName}")]
        public IActionResult GetImage(string folderName, string imageName) 
        { 
            var filePath = Path.Combine(_root, folderName, imageName).Replace("\\", "/");

            if (!System.IO.File.Exists(filePath))
            {
                return NotFound();
            }

            var image = System.IO.File.OpenRead(filePath);

            return File(image, "image/jpeg");
        }
    }
}
