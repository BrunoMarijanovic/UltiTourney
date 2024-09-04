using UltiTourney.API.Models.DTO.City;
using UltiTourney.API.Models.DTO.Image;

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

        public CityDto? City { get; set; }
        public ImageDto? Image { get; set; }
    }
}
