using GovTaskManagement.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace GovTaskManagement.Application.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task<bool> CheckPasswordAsync(ApiUser user, string password);

        Task<IdentityResult> CreateUserAsync(ApiUser user, string password);

        Task<ApiUser> SearchByEmailAsync(string email);

        Task<string> UpdateUserAsync(ApiUser entity);  
    }
}
