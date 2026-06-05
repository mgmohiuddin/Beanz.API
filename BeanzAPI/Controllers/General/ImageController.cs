using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Threading.Tasks;

namespace Beanz.API.Controllers.General
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : Controller
    {
        private readonly IWebHostEnvironment _env;
        public ImageController(IWebHostEnvironment env)
        {
            _env = env;
        }

        [HttpPost("upload")]
        public async Task<IActionResult> UploadImage([FromQuery] string folderPath, [FromForm] IFormFile file)
        {
            if (file == null || file.Length == 0)
                return BadRequest("No file uploaded.");

            // Ensure the folder exists
            var fullPath = Path.Combine(_env.WebRootPath, folderPath);
            if (!Directory.Exists(fullPath))
            {
                Directory.CreateDirectory(fullPath);
            }

            // Save the file
            var filePath = Path.Combine(fullPath, file.FileName);
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return Ok(new { Message = "File uploaded successfully", file.FileName });
        }

        [HttpGet("get")]
        public IActionResult GetImageFullpath([FromQuery] string fullPath)
        {
            if (string.IsNullOrEmpty(fullPath))
            {
                return BadRequest("Full path is required.");
            }

            var imagePath = Path.Combine(_env.WebRootPath, fullPath);

            if (!System.IO.File.Exists(imagePath))
            {
                return NotFound("Image not found.");
            }

            var imageFileStream = System.IO.File.OpenRead(imagePath);
            return File(imageFileStream, "image/jpeg"); // Adjust MIME type if needed
        }

        //[HttpGet("{imageName}")]
        [HttpGet("{folderName}/{imageName}")]
       // [HttpGet("get/{folderName}/{imageName}")]
        public IActionResult GetImage(string folderName, string imageName )
        {
            var imagePath = Path.Combine(_env.WebRootPath + "\\images", folderName, imageName);

            if (!System.IO.File.Exists(imagePath))
            {
                return NotFound("Image not found");
            }

            var imageFileStream = System.IO.File.OpenRead(imagePath);
            return File(imageFileStream, "image/jpeg"); // Adjust MIME type if needed
        }
    }
}
