using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using UltiTourney.API.Models.Domain;
using UltiTourney.API.Models.DTO.City;
using UltiTourney.API.Repositories;

namespace UltiTourney.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitiesController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly ICityRepository cityRepository;

        public CitiesController(IMapper mapper, ICityRepository cityRepository)
        {
            this.mapper = mapper;
            this.cityRepository = cityRepository;
        }

        /// <summary>
        /// List all cities
        /// GET: /api/cities?filterOn=Name&filterQuery=Girona&sortBy=Name&isAscending=true&pageNumber=1&pageSize=10
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] string? filterOn,
            [FromQuery] string? filterQuery, [FromQuery] string? sortBy, [FromQuery] bool isAscending = true,
            [FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            List<City> cities = await cityRepository.GetAllAsync(filterOn, filterQuery,
                sortBy, isAscending, pageNumber, pageSize);

            // Map Domain Model to DTO
            return Ok(mapper.Map<List<CityDto>>(cities));
        }
    }
}
