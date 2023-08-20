namespace NZWalks.API.Models.Domain
{
    public class Walk
    {
        public Guid Id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public double lengthInKm { get; set; }
        public string? walkImageUrl { get; set; }
        public Guid difficultyId { get; set; }
        public Guid regionId { get; set; }

        //Navigation properties
        public Difficulty difficulty { get; set; }
        public Region region { get; set; }

    }
}
