using UltiTourney.API.Models.Domain;

namespace UltiTourney.API.Repositories
{
    public interface IUserTourneyRepository
    {
        Task<UserTourney?> InsertAsync(UserTourney userTourney);
    }
}
