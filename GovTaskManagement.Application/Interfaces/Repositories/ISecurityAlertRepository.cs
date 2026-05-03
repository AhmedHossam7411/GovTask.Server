using GovTaskManagement.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GovTaskManagement.Application.Interfaces.Repositories
{
    public interface ISecurityAlertRepository : IGenericRepository<SecurityAlert, int>
    {
        Task<IEnumerable<SecurityAlert>> GetAllWithSnapshotsAsync();
        Task<SecurityAlert> GetByIdAsync(int id);
    }
}
