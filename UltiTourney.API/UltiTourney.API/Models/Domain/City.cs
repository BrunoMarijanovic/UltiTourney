using System.ComponentModel.DataAnnotations;

namespace UltiTourney.API.Models.Domain
{
    public class City
    {
        public Guid Id { get; set; }
        public Guid IdCountry { get; set; }
        public string Name { get; set; }

        // Navigation properties
        public Country Country { get; set; }
    }
}
