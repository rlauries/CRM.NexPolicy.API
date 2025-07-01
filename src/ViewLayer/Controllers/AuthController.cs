using CRM.NexPolicy.src.ServiceLayer.AuthServices;
using CRM.NexPolicy.src.ViewLayer.DTOs.Auth;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRM.NexPolicy.src.ViewLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("SignUp")]
        public async Task<IActionResult> Register(CreateAgencyDto dto)
        {
            dto.ProfileImageUrl = "/agency-logos/agency_0.jpg";
            var success = await _authService.SignUpAsync(dto);
            if (!success) return BadRequest(new { message = "User already exists." });
            return Ok(new { message = "User created successfully." });
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginDto dto)
        {
            try
            {
                var result = await _authService.LoginAsync(dto);
                if (result == null)
                    return Unauthorized("Invalid credentials.");

                return Ok(result);
            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized(new { message = ex.Message });
            }
        }

    }
}
