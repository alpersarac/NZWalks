using System.ComponentModel.DataAnnotations;

namespace NZWalks.API.Models.DTO
{
    public class AddRegionRequestDto
    {
        [Required]
        [MaxLength(3, ErrorMessage = "Code lenght has to be 3 characters.")]
        [MinLength(3, ErrorMessage = "Code lenght has to be 3 characters.")]
        public string Code { get; set; }
        public string Name { get; set; }
        public string? RegionImageUrl { get; set; }
    }
}
