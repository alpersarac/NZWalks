namespace NZWalks.API.Models.Domain
{
    public class Region
    {
        public Guid Id { get; set; }
        public string code { get; set; }
        public string name { get; set; }
        public string? regionImageUrl { get; set; }
    }
}
