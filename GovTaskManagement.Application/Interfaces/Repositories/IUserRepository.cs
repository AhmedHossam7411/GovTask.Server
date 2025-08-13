using GovTaskManagement.Domain.Entities;


namespace GovTaskManagement.Application.Interfaces.Repositories
{
    public interface IUserRepository : IGenericRepository<ApiUser>
    {
    
        Task<ApiUser> SearchByEmailAsync(string email);
        Task<bool> CheckPasswordAsync(ApiUser user,string password);
        Task<bool> CreateUserAsync(ApiUser user, string password);
    }
}
