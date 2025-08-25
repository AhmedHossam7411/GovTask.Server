using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using GovTaskManagement.Application.Dtos;
using GovTaskManagement.Application.Interfaces.ServiceInterfaces;
using NuGet.Common;

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
            var token = await AuthService.RegisterAsync(registerRequestDto);
            if(token == null)
            {
                return BadRequest("registration failed");
            }
                return Ok("Registration successful");
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequestDto loginRequest)
        {
            var token = await AuthService.LoginAsync(loginRequest);
            if(token == null)
            {
              return Unauthorized("login failed");
            }
            return Ok(new {Token = token});
        }

    }
}
