using GovTaskManagement.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace GovTaskManagement.Application.Interfaces.Repositories
{
    public interface IApiUserRepository
    {
        Task<bool> CheckPasswordAsync(ApiUser user, string password);

        Task<IdentityResult> CreateUserAsync(ApiUser user, string password);

        Task<ApiUser> SearchByEmailAsync(string email);
        Task<bool> ExistsAsync(int id);
        Task<bool> DeleteUserAsync(ApiUser user);
       
    }
}
