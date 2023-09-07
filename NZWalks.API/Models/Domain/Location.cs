namespace NZWalks.API.Models.Domain
{
    public class Location
    {
        public Guid id { get; set; }
        public string name { get; set; }
        public string coordinates { get; set; }

        public Guid difficultyId { get; set; }
        public Difficulty difficulty { get; set; }
    }
}
