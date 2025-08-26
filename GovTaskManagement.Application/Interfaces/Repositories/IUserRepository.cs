using GovTaskManagement.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace GovTaskManagement.Application.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task<bool> CheckPasswordAsync(ApiUser user, string password);

        Task<IdentityResult> CreateUserAsync(ApiUser user, string password);

        Task<ApiUser> SearchByEmailAsync(string email);
        Task<IEnumerable<ApiUser>> GetAllAsync();
        Task<ApiUser> GetAsync(int id);
        Task<bool> ExistsAsync(int id);
        Task<bool> DeleteUserAsync(ApiUser user);
       
        Task<string> UpdateUserAsync(ApiUser entity);
        Task<bool> FindByRoleAndDepartmentAsync(string role, int departmentId);
        Task<bool> FindByRoleAsync(string role);
    }
}
