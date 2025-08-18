using GovTaskManagement.Domain.Entities;
using Microsoft.AspNetCore.Identity;


namespace GovTaskManagement.Application.Interfaces.Repositories
{
    public interface IUserRepository : IGenericRepository<ApiUser>
    {
    
        Task<ApiUser> SearchByEmailAsync(string email);
        Task<bool> CheckPasswordAsync(ApiUser user,string password);
        Task<IdentityResult> CreateUserAsync(ApiUser user, string password);
    }
}
