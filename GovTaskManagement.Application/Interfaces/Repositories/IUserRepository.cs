using GovTaskManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GovTaskManagement.Application.Interfaces.Repositories
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<bool> FindByRoleAndDepartmentAsync(string role, int departmentId);
        Task<bool> FindByRoleAsync(string role);
    }
}
