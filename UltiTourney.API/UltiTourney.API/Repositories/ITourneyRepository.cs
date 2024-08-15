using UltiTourney.API.Models.Domain;

namespace UltiTourney.API.Repositories
{
    public interface ITourneyRepository
    {
        Task<Tourney> UploadAsync(Tourney tourney);
    }
}
