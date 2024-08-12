using AutoMapper;
using UltiTourney.API.Models.Domain;
using UltiTourney.API.Models.DTO.City;

namespace UltiTourney.API.Mappings
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            // City mapping
            CreateMap<City, CityDto>().ReverseMap();
        }
    }
}
