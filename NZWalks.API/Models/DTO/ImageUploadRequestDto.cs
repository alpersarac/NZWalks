using System.ComponentModel.DataAnnotations;

namespace NZWalks.API.Models.DTO
{
    public class ImageUploadRequestDto
    {
        [Required]
        public IFormFile file { get; set; }
        [Required]
        public string fileName { get; set; }
        public string fileDescription { get; set; }
    }
}
