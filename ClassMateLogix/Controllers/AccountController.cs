using BusinessLayer.IServices;
using Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Model;

namespace ClassMateLogix.Controllers
{
    /// <summary>
    /// Controller for managing user accounts and authentication.
    /// </summary>

    [Route("api/account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IApplicationUserService _service;
   //     private readonly IConfiguration _configuration;
  //      private readonly IJwtService _jwtService;
        private readonly UserManager<ApplicationUser> _userManager;
        /// <summary>
        /// Constructor for AccountController.
        /// </summary>
        /// <param name="userService">The application user service to be injected.</param>
        /// <param name="userManager">The user manager for handling user-related operations.</param>
        public AccountController(IApplicationUserService userService, UserManager<ApplicationUser> userManager)
        {
            this._service = userService;
     //       this._configuration = configuration;
            this._userManager = userManager;
//            this._jwtService = jwtService;
        }


        /// <summary>
        /// Register a new user.
        /// </summary>
        /// <param name="registrationDto">The registration data for the new user.</param>
        /// <returns>An action result indicating success or failure of the registration.</returns>

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDTO registrationDto)
        {
            try
            {
                var existingUser = await _userManager.FindByEmailAsync(registrationDto.Email);
                if (existingUser != null)
                {
                    return BadRequest(new { Message = "User with this email already exists." });
                }
                var result = await _service.RegisterAsync(registrationDto);

                if (result.Succeeded) 
                {
                    var response = new
                    {
                        UserData = new { Message = "User registered successfully" }
                    };
                    return Ok(response);

                }
                else
                    return BadRequest(new { Message = "User registration failed", result.Errors });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
        
        /// <summary>
        /// Delete a user by email.
        /// </summary>
        /// <param name="email">The email of the user to delete.</param>
        /// <returns>An action result indicating success or failure of the user deletion.</returns>
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO loginDto)
        {
            try
            {
                var user = await _service.FindByEmailAsync(loginDto.Email);

                if (user != null)
                {
                    
  //                  var token = _jwtService.GenerateJWT(user); //GenerateJwtToken(user);
    /*                var response = new
                    {
                        Token = token,
                        UserData = "User Login successfully"
                    };
      */
                    return Ok("User Login successfully");
                }
                else
                    return Unauthorized(new { Message = "Invalid email" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Get user profile by email.
        /// </summary>
        /// <param name="email">The email of the user to retrieve the profile for.</param>
        /// <returns>An action result containing the user's profile or a message if the user is not found.</returns>
        [HttpGet("profile/{email}")]
        public async Task<IActionResult> GetProfile(string email)
        {
            try
            {
                var profile = await _service.GetProfileAsync(email);
                if (profile != null)
                {
                    return Ok(profile);
                }
                return NotFound("User not found");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Get information for all users.
        /// </summary>
        /// <returns>An action result containing information for all users or an error message.</returns>

        [HttpGet("users")]
        public async Task<IActionResult> GetAllUsersInformation()
        {
            try
            {
                var users = await _service.GetAllUsersInformationAsync();
                return Ok(users);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Edit user profile by email.
        /// </summary>
        /// <param name="email">The email of the user to edit the profile for.</param>
        /// <param name="profileDTO">The profile data to update.</param>
        /// <returns>An action result indicating success or an error message.</returns>

        [HttpPut("edit/{email}")]
        public async Task<IActionResult> EditUser(string email, [FromBody] ProfileDTO profileDTO)
        {
            try
            {
                await _service.EditUserAsync(email, profileDTO);
                return Ok("User updated successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        /// <summary>
        /// Delete a user by email.
        /// </summary>
        /// <param name="email">The email of the user to delete.</param>
        /// <returns>An action result indicating success or an error message.</returns>
        /// 
        [HttpDelete("delete/{email}")]
        public async Task<IActionResult> DeleteUser(string email)
        {
            try
            {
                await _service.RemoveUserAsync(email);
                return Ok("User deleted successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        /*
        // Generate JWT token
        private string GenerateJwtToken(ApplicationUser user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };

            var token = new JwtSecurityToken(
                _configuration["Jwt:Issuer"],
                _configuration["Jwt:Issuer"],
                claims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        */
    }
}
