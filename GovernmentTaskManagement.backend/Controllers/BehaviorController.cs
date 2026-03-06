using GovTaskManagement.Application.Dtos;
using GovTaskManagement.Application.Interfaces.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace GovernmentTaskManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BehaviorController : ControllerBase
    {
        private readonly IBehaviorService _behaviorService;
        public BehaviorController(IBehaviorService behaviorService)
        {
            _behaviorService = behaviorService;
        }
        [HttpPost("snapshot")]
        public async Task<IActionResult> SaveWindow(BehaviorWindowDto dto)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userId == null) 
                return Unauthorized();
            
            await _behaviorService.SaveWindowAsync(dto, userId!);
            return Ok();
        }
    }
}
