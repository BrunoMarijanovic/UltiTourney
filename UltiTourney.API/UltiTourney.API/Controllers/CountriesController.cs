using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UltiTourney.API.Models.Domain;
using UltiTourney.API.Models.DTO.City;
using UltiTourney.API.Models.DTO.Country;
using UltiTourney.API.Repositories;

namespace UltiTourney.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly ICountryRepository countryRepository;

        public CountriesController(IMapper mapper, ICountryRepository cityRepository)
        {
            this.mapper = mapper;
            this.countryRepository = cityRepository;
        }

        /// <summary>
        /// List all countries
        /// GET: /api/countries?filterOn=Name&filterQuery=Girona&sortBy=Name&isAscending=true&pageNumber=1&pageSize=10
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] string? filterOn,
            [FromQuery] string? filterQuery, [FromQuery] string? sortBy, [FromQuery] bool isAscending = true,
            [FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            List<Country> cities = await countryRepository.GetAllAsync(filterOn, filterQuery,
                sortBy, isAscending, pageNumber, pageSize);

            // Map Domain Model to DTO
            return Ok(mapper.Map<List<CountryDto>>(cities));
        }
    }
}
