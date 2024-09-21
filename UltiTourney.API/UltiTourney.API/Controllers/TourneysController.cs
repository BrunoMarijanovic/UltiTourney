﻿using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
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

        public TourneysController(IMapper mapper, ITourneyRepository tourneyRepository)
        {
            this.mapper = mapper;
            this.tourneyRepository = tourneyRepository;
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
            var token = HttpContext.Request.Headers["Authorization"].ToString().Replace("Bearer ", "");

            //if (string.IsNullOrEmpty(token))
            //{
            //    return Unauthorized("Token not found.");
            //}

            //var handler = new JwtSecurityTokenHandler();
            //var jwtToken = handler.ReadJwtToken(token);

            //var userIdClaim = jwtToken.Claims.FirstOrDefault(claim => claim.Type == "userId");

            //if (userIdClaim == null)
            //{
            //    return Unauthorized("User ID not found in token.");
            //}

            //var userId = userIdClaim.Value;

            //AuthController.GetUserIdWithToken("abc");

            // Map Request Model to Domain
            Tourney touruney = mapper.Map<Tourney>(request);
            //touruney.IdUser = userId;

            // Create the row in the DB
            touruney = await tourneyRepository.UploadAsync(touruney);

            // Map Domain Model to DTO
            return Ok(mapper.Map<TourneyDto>(touruney));
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
