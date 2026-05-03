using GovTaskManagement.Application.Interfaces.Repositories;
using GovTaskManagement.Domain.Entities;
using GovTaskManagement.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GovTaskManagement.Infrastructure.Repositories
{
    public class SecurityAlertRepository : GenericRepository<SecurityAlert, int>, ISecurityAlertRepository
    {
        private readonly ToolDbContext _context;

        public SecurityAlertRepository(ToolDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<SecurityAlert>> GetAllWithSnapshotsAsync()
        {
            return await _context.SecurityAlerts
                .Include(a => a.Snapshot)
                .OrderByDescending(a => a.Timestamp)
                .ToListAsync();
        }
        public async Task<SecurityAlert> GetByIdAsync(int id)
        {
            return await _context.SecurityAlerts
                .FirstOrDefaultAsync(alert => alert.Id == id);
        }
    }
}
