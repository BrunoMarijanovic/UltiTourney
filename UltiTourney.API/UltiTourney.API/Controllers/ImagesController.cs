using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UltiTourney.API.Models.Domain;
using UltiTourney.API.Models.DTO.Image;
using UltiTourney.API.Repositories;

namespace UltiTourney.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private readonly IImageRepository imageRepository;

        public ImagesController(IImageRepository imageRepository)
        {
            this.imageRepository = imageRepository;
        }

        /// <summary>
        /// POST: /api/Images/Upload
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Upload")]
        public async Task<IActionResult> Upload([FromForm] ImageUploadRequestDto request)
        {
            ValidateFileUpload(request);

            if (ModelState.IsValid) 
            {
                // Convert DTO to Domain model
                Image imageDomainModel = new Image
                {
                    File = request.File,
                    FileExtension = Path.GetExtension(request.File.FileName),
                    FileSizeInBytes = request.File.Length,
                    FileName = request.FileName,
                    FileDescription = request.FileDescription
                };

                // Upload image
                await imageRepository.Upload(imageDomainModel);

                return Ok(imageDomainModel);
            }

            return BadRequest(ModelState);
        }

        private void ValidateFileUpload(ImageUploadRequestDto request)
        {
            string[] allowedExtensions = new string[] { ".jpg", ".png" };

            if (!allowedExtensions.Contains(Path.GetExtension(request.File.FileName)))
            {
                ModelState.AddModelError("file", "Unsupported file extension.\nOnly allow .jpg and .png");
            }

            // 10MB max file size
            if (request.File.Length > 10485760)
            {
                ModelState.AddModelError("file", "File size more than 10MB.\nPlease upload a smaller size file");
            }
        }
    }
}
