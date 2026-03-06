using GovTaskManagement.Application.Dtos;
using GovTaskManagement.Domain.Entities;

namespace GovTaskManagement.Application.Interfaces.ServiceInterfaces
{
    public interface IBehaviorService
    {
        Task SaveWindowAsync(BehaviorWindowDto dto, string userId);
    }
}
