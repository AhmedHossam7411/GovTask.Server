using GovTaskManagement.Application.Dtos;
using GovTaskManagement.Application.Interfaces.Repositories;
using GovTaskManagement.Application.Interfaces.ServiceInterfaces;
using GovTaskManagement.Domain.Entities;

namespace GovTaskManagement.Application.Services
{
    public class BehaviorService : IBehaviorService   
    {
        private readonly IBehaviorRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        public BehaviorService(IBehaviorRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }
        public async Task SaveWindowAsync(BehaviorWindowDto dto, string userId)
        {
            var entity = new BehaviorWindow
            {
                UserId = userId,
                Context = dto.Context,
                CurrentPage = dto.CurrentPage,
                SessionId = dto.SessionId,
                Timestamp = dto.Timestamp,

                AvgMouseSpeed = dto.AvgMouseSpeed,
                StdMouseSpeed = dto.StdMouseSpeed,
                MouseMoveCount = dto.MouseMoveCount,

                AvgMouseIdle = dto.AvgMouseIdle,
                StdMouseIdle = dto.StdMouseIdle,

                AvgClickDuration = dto.AvgClickDuration,
                StdClickDuration = dto.StdClickDuration,
                ClickCount = dto.ClickCount,

                AvgClickInterval = dto.AvgClickInterval,
                StdClickInterval = dto.StdClickInterval,

                AvgDwell = dto.AvgDwell,
                StdDwell = dto.StdDwell,
                AvgFlight = dto.AvgFlight,
                StdFlight = dto.StdFlight,
                KeyEventCount = dto.KeyEventCount,

                TypingRate = dto.TypingRate
            };

            await _unitOfWork.BehaviorRepository.CreateAsync(entity);
            try
            {
            await _unitOfWork.SaveChangesAsync();

            }catch (Exception e)
            {
                e = e.InnerException;
            }
            
        }
    }
}
