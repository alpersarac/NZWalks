namespace NZWalks.API.Models.DTO
{
    public class UpdateRegionRequestDto
    {
        public string code { get; set; }
        public string name { get; set; }
        public string? regionImageUrl { get; set; }
    }
}
