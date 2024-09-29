using Microsoft.EntityFrameworkCore;
using UltiTourney.API.Data;
using UltiTourney.API.Models.Domain;

namespace UltiTourney.API.Repositories
{
    public class SQLUserRepository:IUserRepository
    {
        private readonly UltiTourneyDbContext dbContext;

        public SQLUserRepository(UltiTourneyDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        /// <summary>
        /// Return the user with the given user's email
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<ApplicationUser?> GetUserByEmailAsync(string email)
        {
            ApplicationUser? user = await dbContext.Users
                .FirstOrDefaultAsync(x => x.Email.Equals(email));

            if (user == null)
                throw new Exception("User not found with emial: " + email);

            return user;
        }
    }
}
