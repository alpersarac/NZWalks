using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NZWalks.API.Models.Domain;
using NZWalks.API.Models.DTO;

namespace NZWalks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        [HttpPost]
        [Route("Upload")]
        public async Task<IActionResult> Upload([FromBody] ImageUploadRequestDto request)
        {
            ValidateFileUpload(request);
            if (ModelState.IsValid)
            {
                var imageDomainModel = new Image
                {
                    file = request.file,
                    fileExtention = Path.GetExtension(request.file.FileName),
                    fileDescription=request.fileDescription,
                    fileName = request.fileName,
                    fileSizeInBytes=request.file.Length,
                };
            }
            return BadRequest(ModelState);
        }
        private void ValidateFileUpload(ImageUploadRequestDto request)
        {
            var allowedExtentions = new string[] { ".jpg", ".jpeg", ".png" };
            if (!allowedExtentions.Contains(Path.GetExtension(request.file.FileName)))
            {
                ModelState.AddModelError("file", "Unsupported file extension");
            }
            if (request.file.Length > 10485760)
            {
                ModelState.AddModelError("file", "File size is greater than 10MB, please upload a small sized file.");
            }
        }
    }
}
