using Microsoft.AspNetCore.Identity;

namespace UltiTourney.API.Models.Domain
{
    public class ApplicationUser : IdentityUser
    {
        public ICollection<UserTourney> UserTourneys { get; set; }
    }
}
