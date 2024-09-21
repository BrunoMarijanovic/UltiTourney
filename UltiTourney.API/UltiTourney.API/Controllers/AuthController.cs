using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using UltiTourney.API.Models.Domain;
using UltiTourney.API.Models.DTO.Auth;
using UltiTourney.API.Repositories;

namespace UltiTourney.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly ITokenRepository tokenRepository;

        public AuthController(UserManager<ApplicationUser> userManager, ITokenRepository tokenRepository)
        {
            this.userManager = userManager;
            this.tokenRepository = tokenRepository;
        }

        /// <summary>
        /// POST: /api/Auth/Register
        /// Create a user
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequestDto registerRequestDto)
        {
            ApplicationUser identityUser = new ApplicationUser
            {
                UserName = registerRequestDto.Username,
                Email = registerRequestDto.Username,
            };

            IdentityResult identityResult = await userManager.CreateAsync(identityUser, registerRequestDto.Password);

            if (identityResult.Succeeded) 
            {
                // Add roles to this User
                if (registerRequestDto.Roles != null && registerRequestDto.Roles.Length != 0)
                {
                    identityResult = await userManager.AddToRolesAsync(identityUser, registerRequestDto.Roles);

                    if (identityResult.Succeeded)
                        return Ok("User registered! Please login.");
                }
            }
            else if (identityResult.Errors.Count() > 0)
            {
                StringBuilder result = new StringBuilder();

                foreach (IdentityError error in identityResult.Errors)
                {
                    result.Append(error.Description);
                }

                return BadRequest(result.ToString());
            }

            return BadRequest("Something went wrong.");
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto loginRequestDto)
        {
            ApplicationUser? user = await userManager.FindByEmailAsync(loginRequestDto.Username);

            if (user != default)
            {
                bool checkPasswordResult = await userManager.CheckPasswordAsync(user, loginRequestDto.Password);

                if (checkPasswordResult)
                {
                    // Get user's roles
                    IList<string> roles = await userManager.GetRolesAsync(user);

                    if (roles != null)
                    {
                        // Create token
                        LoginResponseDto response = new LoginResponseDto
                        {
                            JwtToken = tokenRepository.CreateJWTToken(user, roles.ToList())
                        };

                        return Ok(response);
                    }
                }
                else
                    BadRequest("Incorrect password.");
            }

            return BadRequest("Username or password incorrect.");
        }
    }
}
