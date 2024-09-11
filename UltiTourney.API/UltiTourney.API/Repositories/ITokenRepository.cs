using Microsoft.AspNetCore.Identity;

namespace UltiTourney.API.Repositories
{
    public interface ITokenRepository
    {
        string CreateJWTToken(IdentityUser user, List<string> roles);
    }
}
