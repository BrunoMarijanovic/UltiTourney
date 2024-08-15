namespace UltiTourney.API.Models.DTO.Tourney
{
    public class TourneyDto
    {
        public Guid Id { get; set; }
        public Guid IdCity { get; set; }
        public string Name { get; set; }
        public Guid? IdImage { get; set; }
        public DateOnly? StartDate { get; set; }
        public DateOnly? EndDate { get; set; }
        public string? UrlGoogleMaps { get; set; }
        public string? Description { get; set; }
        public bool Deleted { get; set; }
    }
}
