using System.ComponentModel.DataAnnotations;

namespace UltiTourney.API.Models.Domain
{
    public class Country
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        // Navigation property
        public ICollection<City> Cities { get; set; }
    }
}
