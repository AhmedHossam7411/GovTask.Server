using GovTaskManagement.Application.Interfaces.Repositories;
using GovTaskManagement.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace GovTaskManagement.Infrastructure.Repositories
{
    public class ApiUserRepository : IApiUserRepository
    {
        private readonly UserManager<ApiUser> _userManager;

        public ApiUserRepository(UserManager<ApiUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<bool> CheckPasswordAsync(ApiUser user, string password)
        {
            return await _userManager.CheckPasswordAsync(user, password);
        }

        public async Task<IdentityResult> CreateUserAsync(ApiUser user, string password )
        {
           return await _userManager.CreateAsync(user, password);
        }

        public async Task<IdentityResult> DeleteUserAsync(ApiUser user)
        {
           
            return await _userManager.DeleteAsync(user);
        }

        public async Task<bool> ExistsAsync(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            return user != null;
        }
        public async Task<ApiUser?> FindByIdAsync(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            return user;
        }

        //public async Task<bool> FindByRoleAsync(string role)
        //{
        //    return await _context.Users.AnyAsync(u => _userManager.IsInRoleAsync(u , role).Result);
        //}

        //public override async Task<IEnumerable<ApiUser>> GetAllAsync()
        //{
        //    return await _userManager.Users.ToListAsync();
        //}

        //public override async Task<ApiUser> GetAsync(int id)
        //{
        //    return await _userManager.FindByIdAsync(id.ToString());
        //}

        public async Task<ApiUser?> SearchByEmailAsync(string email)
        {
            return await _userManager.FindByEmailAsync(email);
        }

        
    }
}
