using UltiTourney.API.Data;
using UltiTourney.API.Models.Domain;

namespace UltiTourney.API.Repositories
{
    public class LocalImageRepository : IImageRepository
    {
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly UltiTourneyDbContext dbContext;

        public LocalImageRepository(IWebHostEnvironment webHostEnvironment,
            IHttpContextAccessor httpContextAccessor, UltiTourneyDbContext dbContext)
        {
            this.webHostEnvironment = webHostEnvironment;
            this.httpContextAccessor = httpContextAccessor;
            this.dbContext = dbContext;
        }

        public async Task<Image> Upload(Image image)
        {
            string localFilePath = Path.Combine(webHostEnvironment.ContentRootPath, "Images", 
                $"{image.FileName}{image.FileExtension}");

            // Upload Image to Local Path
            using FileStream stream = new FileStream(localFilePath, FileMode.Create);
            await image.File.CopyToAsync(stream);

            string urlFilePath = $"{httpContextAccessor.HttpContext.Request.Scheme}" +
                $"://{httpContextAccessor.HttpContext.Request.Host}" +
                $"{httpContextAccessor.HttpContext.Request.PathBase}/Images/" +
                $"{image.FileName}{image.FileExtension}";

            image.FilePath = urlFilePath;

            // Add Image to Images table DB
            await dbContext.Images.AddAsync(image);
            await dbContext.SaveChangesAsync();

            return image;
        }
    }
}
