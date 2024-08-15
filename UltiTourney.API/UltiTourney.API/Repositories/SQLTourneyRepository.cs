using UltiTourney.API.Data;
using UltiTourney.API.Models.Domain;

namespace UltiTourney.API.Repositories
{
    public class SQLTourneyRepository: ITourneyRepository
    {
        private readonly UltiTourneyDbContext dbContext;

        public SQLTourneyRepository(UltiTourneyDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Tourney> UploadAsync(Tourney tourney)
        {
            await dbContext.Tourneys.AddAsync(tourney);
            await dbContext.SaveChangesAsync();
            return tourney;
        }
    }
}
