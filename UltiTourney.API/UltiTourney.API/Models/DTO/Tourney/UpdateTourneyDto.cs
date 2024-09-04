using System.ComponentModel.DataAnnotations;

namespace UltiTourney.API.Models.DTO.Tourney
{
    public class UpdateTourneyDto
    {
        [Required]
        public Guid IdCity { get; set; }

        [Required]
        public string Name { get; set; }

        public Guid? IdImage { get; set; }
        public DateOnly? StartDate { get; set; }
        public DateOnly? EndDate { get; set; }
        public string? UrlGoogleMaps { get; set; }
        public string? Description { get; set; }
    }
}
