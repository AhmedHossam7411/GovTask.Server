using GovTaskManagement.Application.Dtos;
using GovTaskManagement.Application.Interfaces.ServiceInterfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Security.Claims;
using System.Threading.Tasks;

namespace GovernmentTaskManagement.backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SecurityController : ControllerBase
    {
        private readonly ISecurityService _securityService;
        private readonly IEmailService _emailService;
        private readonly IConfiguration _configuration;

        public SecurityController(ISecurityService securityService, IEmailService emailService, IConfiguration configuration)
        {
            _securityService = securityService;
            _emailService = emailService;
            _configuration = configuration;
        }

        [HttpPost("alert-admin")]
        public async Task<IActionResult> CreateAlert([FromBody] SecurityAlertDto dto)
        {
            // Enrich with server-verified identity when the user is authenticated
            if (User.Identity?.IsAuthenticated == true)
            {
                dto.UserId ??= User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                dto.UserEmail ??= User.FindFirst(ClaimTypes.Email)?.Value
                               ?? User.FindFirst(ClaimTypes.Name)?.Value;
            }

            await _securityService.CreateAlertAsync(dto);
            return Ok();
        }

        [HttpPost("test-email")]
        public async Task<IActionResult> TestEmail()
        {
            var adminEmail = _configuration["EmailSettings:AdminEmail"];
            if (string.IsNullOrEmpty(adminEmail))
                return BadRequest("AdminEmail is not configured in appsettings.");

            await _emailService.SendTemplatedEmailAsync(
                adminEmail,
                "[GovTask] Test Email — SMTP Configuration OK",
                "TestEmail",
                new { AdminEmail = adminEmail, Timestamp = DateTime.UtcNow.ToString("R") });

            return Ok(new { message = $"Test email sent to {adminEmail}" });
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("alerts")]
        public async Task<IActionResult> GetAlerts()
        {
            var alerts = await _securityService.GetAlertsAsync();
            return Ok(alerts);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("resolve-alert/{id}")]
        public async Task<IActionResult> ResolveAlert(int id)
        {
            await _securityService.ResolveAlertAsync(id);
            return Ok();
        }
    }
}
