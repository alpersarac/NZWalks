using System.ComponentModel.DataAnnotations.Schema;

namespace NZWalks.API.Models.Domain
{
    public class Image
    {
        public Guid id { get; set; }
        [NotMapped]
        public IFormFile file { get; set; }
        public string fileName { get; set; }
        public string? fileDescription { get; set; }
        public string fileExtention { get; set; }
        public long fileSizeInBytes { get; set; }
        public string filePath { get; set; }

    }
}
