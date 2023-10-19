namespace NZWalks.API.Models.DTO
{
    public class RegionDto
    {
        public Guid Id { get; set; }
        public string code { get; set; }
        public string name { get; set; }
        public string? regionImageUrl { get; set; }
    }
}
