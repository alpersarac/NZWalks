namespace NZWalks.API.Models.Domain
{
    public class Location
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Coordinates { get; set; }

        public Guid DifficultyId { get; set; }
        public Difficulty Difficulty { get; set; }
    }
}
