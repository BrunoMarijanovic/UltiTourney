using Microsoft.EntityFrameworkCore;
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

        /// <summary>
        /// Get all the cities depending the filter values.
        /// It's necessary paginate the values.
        /// </summary>
        /// <param name="filterOn"></param>
        /// <param name="filterQuery"></param>
        /// <param name="sortBy"></param>
        /// <param name="isAscending"></param>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public async Task<List<Tourney>> GetAllAsync(string? filterOn = null, string? filterQuery = null, 
            string? sortBy = null, DateOnly? startDate = null, DateOnly? endDate = null,
            bool isAscending = true, int pageNumber = 1, int pageSize = 10)
        {
            IQueryable<Tourney> tourneys = dbContext.Tourneys
                .Include(x => x.City)
                .Include(x => x.Image)
                .AsQueryable();

            // Filtering
            if (string.IsNullOrWhiteSpace(filterOn) == false && string.IsNullOrWhiteSpace(filterQuery) == false)
            {
                if (filterOn.Equals("IdCity", StringComparison.OrdinalIgnoreCase))
                {
                    tourneys = tourneys.Where(x => x.IdCity.Equals(filterQuery));
                }

                if (filterOn.Equals("Name", StringComparison.OrdinalIgnoreCase))
                {
                    tourneys = tourneys.Where(x => x.Name.Contains(filterQuery));
                }

                // Filter by Date Range
                if (startDate.HasValue && endDate.HasValue)
                {
                    tourneys = tourneys.Where(x => x.StartDate >= startDate.Value && x.EndDate <= endDate.Value);
                }
                else if (startDate.HasValue)
                {
                    tourneys = tourneys.Where(x => x.StartDate >= startDate.Value);
                }
                else if (endDate.HasValue)
                {
                    tourneys = tourneys.Where(x => x.EndDate <= endDate.Value);
                }
            }

            // Sorting
            if (string.IsNullOrWhiteSpace(sortBy) == false)
            {
                if (sortBy.Equals("Name", StringComparison.OrdinalIgnoreCase))
                {
                    tourneys = isAscending ? tourneys.OrderBy(x => x.Name) : tourneys.OrderByDescending(x => x.Name);
                }
            }

            // Pagination
            int skipResults = (pageNumber - 1) * pageSize;

            return await tourneys.Skip(skipResults).Take(pageSize).ToListAsync();
        }

        public async Task<Tourney?> GetByIdAsync(Guid id)
        {
            return await dbContext.Tourneys
                .Include(x => x.City)
                .Include(x => x.Image)
                .FirstOrDefaultAsync(x => x.Id.Equals(id));
        }

        /// <summary>
        /// Insert in DB a new tourney
        /// </summary>
        /// <param name="tourney"></param>
        /// <returns></returns>
        public async Task<Tourney> UploadAsync(Tourney tourney)
        {
            await dbContext.Tourneys.AddAsync(tourney);
            await dbContext.SaveChangesAsync();
            return tourney;
        }
    }
}
