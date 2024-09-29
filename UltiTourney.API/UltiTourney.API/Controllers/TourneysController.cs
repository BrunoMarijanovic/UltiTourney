using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using UltiTourney.API.Models.Domain;
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
        private readonly IUserRepository userRepository;
        private readonly IUserTourneyRepository userTourneyRepository;

        public TourneysController(IMapper mapper, ITourneyRepository tourneyRepository, 
            IUserRepository userRepository, IUserTourneyRepository userTourneyRepository)
        {
            this.mapper = mapper;
            this.tourneyRepository = tourneyRepository;
            this.userRepository = userRepository;
            this.userTourneyRepository = userTourneyRepository;
        }

        /// <summary>
        /// GET: /api/Tourney
        /// </summary>
        /// <param name="filterOn"></param>
        /// <param name="filterQuery"></param>
        /// <param name="sortBy"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="isAscending"></param>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [HttpGet]
        [Authorize(Roles = "Admin,SuperAdmin")]
        public async Task<IActionResult> GetAll(string? filterOn = null, string? filterQuery = null,
            string? sortBy = null, DateOnly? startDate = null, DateOnly? endDate = null,
            bool isAscending = true, int pageNumber = 1, int pageSize = 10)
        {
            List<Tourney> tourneys = await tourneyRepository.GetAllAsync(filterOn, filterQuery,
                sortBy, startDate, endDate, isAscending, pageNumber, pageSize);

            // Map Domain Model to DTO
            return Ok(mapper.Map<List<TourneyDto>>(tourneys));
        }
        
        /// <summary>
        /// GET: /api/Tourneys?id
        /// Get a Tourney by Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            Tourney? tourney = await tourneyRepository.GetByIdAsync(id);

            if (tourney == default)
                return NotFound();

            return Ok(mapper.Map<TourneyDto>(tourney));
        }

        /// <summary>
        /// POST: /api/Tourneys
        /// Creates a new tourney
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize(Roles = "Admin,SuperAdmin")]
        public async Task<IActionResult> Upload([FromBody] TourneyUploadRequestDto request)
        {
            // Retrieve the user's email from the claims
            string? userEmail = HttpContext.User.FindFirstValue(ClaimTypes.Email);

            if (userEmail == null)
                return BadRequest("User email not found");

            // Retrieve the user ID from the database based on the email
            var user = await userRepository.GetUserByEmailAsync(userEmail);

            if (user == null)
                return BadRequest("User not found");

            // Map Request Model to Domain
            Tourney tourney = mapper.Map<Tourney>(request);

            // Create the row in the DB
            tourney = await tourneyRepository.UploadAsync(tourney);

            // Insert into UserTourneys table to create DB relationship
            var userTourney = new UserTourney
            {
                User = user,
                UserId = user.Id,
                Tourney = tourney,
                TourneyId = tourney.Id
            };

            await userTourneyRepository.InsertAsync(userTourney);

            // Map Domain Model to DTO
            return Ok(mapper.Map<TourneyDto>(tourney));
        }

        /// <summary>
        /// PUT: /api/Tourneys
        /// Modify tourney data
        /// </summary>
        /// <param name="id"></param>
        /// <param name="updateTourneyDto"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("{id:Guid}")]
        [Authorize]
        [Authorize(Roles = "Admin,SuperAdmin")]
        public async Task<IActionResult> ModifyTourney([FromRoute] Guid id, [FromBody] UpdateTourneyDto updateTourneyDto)
        {
            Tourney? tourney = mapper.Map<Tourney>(updateTourneyDto);

            tourney = await tourneyRepository.ModifyByIdAsync(id, tourney);

            if (tourney == default)
                return NotFound();

            return Ok(mapper.Map<TourneyDto>(tourney));
        }

    }
}
