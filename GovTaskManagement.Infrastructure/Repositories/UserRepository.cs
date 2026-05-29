using GovTaskManagement.Application.Interfaces.Repositories;
using GovTaskManagement.Domain.Entities;
using GovTaskManagement.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace GovTaskManagement.Infrastructure.Repositories
{
    public class UserRepository : GenericRepository<User, int>, IUserRepository
    {
        private readonly ToolDbContext _context;

        public UserRepository(ToolDbContext context) : base(context)
        {
            _context = context;
        }

        public Task<bool> FindByRoleAndDepartmentAsync(string role, int departmentId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> FindByRoleAsync(string role)
        {
            throw new NotImplementedException();
        }

        public Task<User?> GetByApiUserIdAsync(string apiUserId)
        {
            return _context.Set<User>().FirstOrDefaultAsync(u => u.ApiUserId == apiUserId);
        }
    }
}
