using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UltiTourney.API.Models.Domain;
using UltiTourney.API.Models.DTO.City;
using UltiTourney.API.Models.DTO.Image;
using UltiTourney.API.Models.DTO.Tourney;
using UltiTourney.API.Repositories;

namespace UltiTourney.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TourneysController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly ITourneyRepository tourneyRepository;

        public TourneysController(IMapper mapper, ITourneyRepository tourneyRepository)
        {
            this.mapper = mapper;
            this.tourneyRepository = tourneyRepository;
        }

        /// <summary>
        /// POST: /api/Tourneys
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Upload([FromBody] TourneyUploadRequestDto request)
        {
            // Map Request Model to Domain
            Tourney touruney = mapper.Map<Tourney>(request);

            // Create the row in the DB
            touruney = await tourneyRepository.UploadAsync(touruney);

            // Map Domain Model to DTO
            return Ok(mapper.Map<TourneyDto>(touruney));
        }
    }
}
