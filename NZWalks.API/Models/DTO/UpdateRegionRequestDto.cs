using System.ComponentModel.DataAnnotations;

namespace NZWalks.API.Models.DTO
{
    public class UpdateRegionRequestDto
    {
        [Required]
        [MaxLength(3, ErrorMessage = "Code lenght has to be 3 characters.")]
        [MinLength(3, ErrorMessage = "Code lenght has to be 3 characters.")]
        public string Code { get; set; }
        [Required]
        [MaxLength(100, ErrorMessage = "Name lenght has to be 3 characters.")]
        public string Name { get; set; }
        public string? RegionImageUrl { get; set; }
    }
}
