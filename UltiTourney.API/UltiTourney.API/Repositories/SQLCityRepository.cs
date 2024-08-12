using Microsoft.EntityFrameworkCore;
using System.Globalization;
using UltiTourney.API.Data;
using UltiTourney.API.Models.Domain;

namespace UltiTourney.API.Repositories
{
    public class SQLCityRepository : ICityRepository
    {
        private readonly UltiTourneyDbContext dbContext;

        public SQLCityRepository(UltiTourneyDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        /// <summary>
        /// Get all the cities depending the filter values.
        /// It's necessary paginate the values.
        /// </summary>
        /// <param name="filterOn">Table to filter</param>
        /// <param name="filterQuery">Value to fileter</param>
        /// <param name="sortBy">Table to sort</param>
        /// <param name="isAscending"></param>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public async Task<List<City>> GetAllAsync(string? filterOn = null, string? filterQuery = null,
            string? sortBy = null, bool isAscending = true, int pageNumber = 1, int pageSize = 10)
        {
            IQueryable<City> cities = dbContext.Cities.AsQueryable();

            // Filtering
            if (string.IsNullOrWhiteSpace(filterOn) == false && string.IsNullOrWhiteSpace(filterQuery) == false)
            {
                if (filterOn.Equals("IdCountry", StringComparison.OrdinalIgnoreCase))
                {
                    cities = cities.Where(x => x.IdCountry.Equals(filterQuery));
                }

                if (filterOn.Equals("Name", StringComparison.OrdinalIgnoreCase))
                {
                    cities = cities.Where(x => x.Name.Contains(filterQuery));
                }
            }

            // Sorting
            if (string.IsNullOrWhiteSpace(sortBy) == false)
            {
                if (sortBy.Equals("Name", StringComparison.OrdinalIgnoreCase))
                {
                    cities = isAscending ? cities.OrderBy(x => x.Name) : cities.OrderByDescending(x => x.Name);
                }
            }

            // Pagination
            int skipResults = (pageNumber - 1) * pageSize;

            return await cities.Skip(skipResults).Take(pageSize).ToListAsync();
        }
    }
}
