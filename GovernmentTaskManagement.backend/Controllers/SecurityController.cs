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
        private readonly ISuspensionService _suspensionService;

        public SecurityController(ISecurityService securityService, IEmailService emailService,
            IConfiguration configuration, ISuspensionService suspensionService)
        {
            _securityService = securityService;
            _emailService = emailService;
            _configuration = configuration;
            _suspensionService = suspensionService;
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("revoke-user")]
        public IActionResult RevokeUser([FromBody] string userId)
        {
            if (string.IsNullOrEmpty(userId))
                return BadRequest();
            _suspensionService.RevokeUser(userId);
            return Ok();
        }

        [Authorize]
        [HttpPost("suspend-user")]
        public IActionResult SuspendUser()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userId))
                return Unauthorized();

            _suspensionService.SuspendUser(userId);
            return Ok();
        }

        [HttpPost("alert-admin")]
        public async Task<IActionResult> CreateAlert([FromBody] SecurityAlertDto dto)
        {
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

        [Authorize]
        [HttpGet("challenge-questions")]
        public IActionResult GetChallengeQuestions()
        {
            return Ok(new
            {
                question1 = _configuration["ChallengeKnowledge:Question1"] ?? "Security question 1",
                question2 = _configuration["ChallengeKnowledge:Question2"] ?? "Security question 2"
            });
        }

        [HttpPost("verify-knowledge")]
        public IActionResult VerifyKnowledge([FromBody] VerifyKnowledgeDto dto)
        {
            var expected1 = _configuration["ChallengeKnowledge:Answer1"] ?? "";
            var expected2 = _configuration["ChallengeKnowledge:Answer2"] ?? "";

            bool correct =
                string.Equals(dto.Answer1.Trim(), expected1.Trim(), StringComparison.OrdinalIgnoreCase) &&
                string.Equals(dto.Answer2.Trim(), expected2.Trim(), StringComparison.OrdinalIgnoreCase);

            if (!correct)
                return BadRequest(new { error = "Incorrect answers." });

            return Ok();
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
