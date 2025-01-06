namespace NZWalks.API.Models.Domain
{
    public class Walks
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public double LengthInKm { get; set; }
        public string? WalkImageUrl { get; set; }
        public Guid RegionId { get; set; }
        public Guid DeficultyId { get; set; }

        //Navigation properties
        public required Regions Region { get; set; }
        public required Difficulty Deficulty { get; set; }
    }
}
