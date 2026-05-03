using GovTaskManagement.Application.Dtos;
using GovTaskManagement.Application.Interfaces.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace GovernmentTaskManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MLPredictionController(IMLService _mLService) : ControllerBase
    {
        [HttpPost("predict")]
        public async Task<IActionResult> Predict(MlPredictionRequestDto dto)
        {
            await _mLService.PredictAsync(dto);
            return Ok(dto);
        }
    }
}
