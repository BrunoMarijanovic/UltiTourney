using UltiTourney.API.Models.Domain;

namespace UltiTourney.API.Repositories
{
    public interface IImageRepository
    {
        Task<Image> Upload(Image image);
    }
}
