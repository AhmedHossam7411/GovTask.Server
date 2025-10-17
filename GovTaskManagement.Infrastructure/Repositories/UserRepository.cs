using GovTaskManagement.Application.Interfaces.Repositories;
using GovTaskManagement.Domain.Entities;
using GovTaskManagement.Infrastructure.Data;

namespace GovTaskManagement.Infrastructure.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {

        public UserRepository(ToolDbContext context) : base(context)
        {
            
        }
        public Task<bool> FindByRoleAndDepartmentAsync(string role, int departmentId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> FindByRoleAsync(string role)
        {
            throw new NotImplementedException();
        }
    }
}
