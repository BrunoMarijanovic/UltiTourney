using Microsoft.EntityFrameworkCore;
using UltiTourney.API.Data;
using UltiTourney.API.Models.Domain;

namespace UltiTourney.API.Repositories
{
    public class SQLCountryRepository: ICountryRepository
    {
        private readonly UltiTourneyDbContext dbContext;

        public SQLCountryRepository(UltiTourneyDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<List<Country>> GetAllAsync(string? filterOn = null, string? filterQuery = null, 
            string? sortBy = null, bool isAscending = true, int pageNumber = 1, int pageSize = 10)
        {
            IQueryable<Country> countries = dbContext.Countries.AsQueryable();

            // Filtering
            if (string.IsNullOrWhiteSpace(filterOn) == false && string.IsNullOrWhiteSpace(filterQuery) == false)
            {
                if (filterOn.Equals("Id", StringComparison.OrdinalIgnoreCase))
                {
                    countries = countries.Where(x => x.Id.Equals(filterQuery));
                }

                if (filterOn.Equals("Name", StringComparison.OrdinalIgnoreCase))
                {
                    countries = countries.Where(x => x.Name.Contains(filterQuery));
                }
            }

            // Sorting
            if (string.IsNullOrWhiteSpace(sortBy) == false)
            {
                if (sortBy.Equals("Name", StringComparison.OrdinalIgnoreCase))
                {
                    countries = isAscending ? countries.OrderBy(x => x.Name) : countries.OrderByDescending(x => x.Name);
                }
            }

            // Pagination
            int skipResults = (pageNumber - 1) * pageSize;

            return await countries.Skip(skipResults).Take(pageSize).ToListAsync();
        }
    }
}
