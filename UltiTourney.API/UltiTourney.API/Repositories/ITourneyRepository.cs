using UltiTourney.API.Models.Domain;

namespace UltiTourney.API.Repositories
{
    public interface ITourneyRepository
    {
        Task<Tourney> UploadAsync(Tourney tourney);

        Task<List<Tourney>> GetAllAsync(string? filterOn = null, string? filterQuery = null,
            string? sortBy = null, DateOnly? startDate = null, DateOnly? endDate = null,
            bool isAscending = true, int pageNumber = 1, int pageSize = 10);
    }
}
