using Microsoft.AspNetCore.Identity;
using UltiTourney.API.Models.Domain;

namespace UltiTourney.API.Repositories
{
    public interface IUserRepository
    {
        Task<ApplicationUser?> GetUserByEmailAsync(string email);
    }
}
