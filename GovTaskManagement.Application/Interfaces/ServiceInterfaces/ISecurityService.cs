using GovTaskManagement.Application.Dtos;
using GovTaskManagement.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GovTaskManagement.Application.Interfaces.ServiceInterfaces
{
    public interface ISecurityService
    {
        Task CreateAlertAsync(SecurityAlertDto dto);
        Task<IEnumerable<SecurityAlert>> GetAlertsAsync();
        Task ResolveAlertAsync(int id);
    }
}
