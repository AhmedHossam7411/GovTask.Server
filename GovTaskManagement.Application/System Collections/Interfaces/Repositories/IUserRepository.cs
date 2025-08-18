using GovTaskManagement.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace GovTaskManagement.Infrastructure.Repositories
{
    public interface IUserRepository
    {
        Task<bool> CheckPasswordAsync(ApiUser user, string password);

        Task<IdentityResult> CreateUserAsync(ApiUser user, string password);

        Task<ApiUser> SearchByEmailAsync(string email);

        Task<String> UpdateUserAsync(ApiUser entity);  
    }
}
