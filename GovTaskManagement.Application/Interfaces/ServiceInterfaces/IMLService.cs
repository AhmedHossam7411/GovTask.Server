
using GovTaskManagement.Application.Dtos;

namespace GovTaskManagement.Application.Interfaces.ServiceInterfaces
{
    public interface IMLService
    {
        Task<MlPredictionResponseDto> PredictAsync(object data);
    }
}

