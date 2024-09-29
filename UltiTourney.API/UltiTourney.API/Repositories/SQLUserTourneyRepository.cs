using UltiTourney.API.Data;
using UltiTourney.API.Models.Domain;

namespace UltiTourney.API.Repositories
{
    public class SQLUserTourneyRepository:IUserTourneyRepository
    {
        private readonly UltiTourneyDbContext dbContext;

        public SQLUserTourneyRepository(UltiTourneyDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        /// <summary>
        /// Add a row in the UserTourney table
        /// </summary>
        /// <param name="userTourney"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<UserTourney?> InsertAsync(UserTourney userTourney)
        {
            await dbContext.UserTourneys.AddAsync(userTourney);
            await dbContext.SaveChangesAsync();
            return userTourney;
        }
    }
}
