using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using UltiTourney.API.Models.DTO.Auth;

namespace UltiTourney.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<IdentityUser> userManager;

        public AuthController(UserManager<IdentityUser> userManager)
        {
            this.userManager = userManager;
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
            IdentityUser identityUser = new IdentityUser
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
    }
}
