using AutoMapper;
using UltiTourney.API.Models.Domain;
using UltiTourney.API.Models.DTO.City;
using UltiTourney.API.Models.DTO.Country;
using UltiTourney.API.Models.DTO.Tourney;

namespace UltiTourney.API.Mappings
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            // City mapping
            CreateMap<City, CityDto>().ReverseMap();

            // Country mapping
            CreateMap<Country, CountryDto>().ReverseMap();

            // Tourneys
            CreateMap<TourneyUploadRequestDto, Tourney>().ReverseMap();
            CreateMap<Tourney, TourneyDto>().ReverseMap();
        }
    }
}
