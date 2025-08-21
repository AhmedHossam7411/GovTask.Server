using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using GovTaskManagement.Application.Dtos;
using GovTaskManagement.Application.Interfaces.ServiceInterfaces;

namespace GovernmentTaskManagement.Api.Endpoints
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService AuthService;

        public AuthController(IAuthService _authService)
        {
            AuthService = _authService;

        }
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequestDto registerRequestDto)
        {
            var result = await AuthService.RegisterAsync(registerRequestDto);
            if(result.Succeeded)
            {
                return Ok("Registration successful");
            }
            return BadRequest("registration failed");
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequestDto loginRequest)
        {
            var result = await AuthService.LoginAsync(loginRequest);
            if(result != false)
            {
                return Ok("login successful");
            }
            return BadRequest("login failed");
        }

    }
}
