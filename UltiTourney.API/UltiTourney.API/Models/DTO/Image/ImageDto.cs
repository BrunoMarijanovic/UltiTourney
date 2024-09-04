using System.ComponentModel.DataAnnotations.Schema;

namespace UltiTourney.API.Models.DTO.Image
{
    public class ImageDto
    {
        public Guid Id { get; set; }
        public string FileName { get; set; }
        public string? FileDescription { get; set; }
        public string FileExtension { get; set; }
        public string FilePath { get; set; }
    }
}
