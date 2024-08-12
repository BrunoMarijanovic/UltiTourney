using UltiTourney.API.Models.Domain;

namespace UltiTourney.API.Repositories
{
    public interface ICityRepository
    {
        Task<List<City>> GetAllAsync(string? filterOn = null, string? filterQuery = null,
            string? sortBy = null, bool isAscending = true,
            int pageNumber = 1, int pageSize = 10);
    }
}
