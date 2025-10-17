using GovTaskManagement.Application.Interfaces.Repositories;
using GovTaskManagement.Domain.Entities;
using GovTaskManagement.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace GovTaskManagement.Infrastructure.Repositories
{
    public class DepartmentRepository : GenericRepository<DepartmentEntity>, IDepartmentRepository

    {
        private readonly ToolDbContext context;
        public DepartmentRepository(ToolDbContext _context) : base(_context)
        {
            context = _context;

        }
        public async Task<DepartmentEntity?> GetDepartmentByTaskId(int taskId)
        {
            return await context.Departments.Include(dep => dep.Tasks)
                .FirstOrDefaultAsync(dep => dep.Tasks.Any(task => task.Id == taskId));
            
        }

        public async Task<DepartmentEntity?> GetDepartmentByUserId(string userId)
        {
            var userID = context.UserClaims.FirstOrDefault(c => c.ClaimValue == userId)?.ClaimValue;
            
            return await context.Departments.Include(dep => dep.Users)
                .FirstOrDefaultAsync(dep => dep.Users.Any(user => user.ApiUserId == userID));
            
        }
    }
}
