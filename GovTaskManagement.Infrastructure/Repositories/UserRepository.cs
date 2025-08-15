using GovTaskManagement.Application.Interfaces.Repositories;
using GovTaskManagement.Domain.Entities;
using GovTaskManagement.Infrastructure.Data;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GovTaskManagement.Infrastructure.Repositories
{
    public class UserRepository : GenericRepository<ApiUser> , IUserRepository
    {
        private readonly UserManager<ApiUser> userManager;
        private readonly toolDbContext context;


        public UserRepository(UserManager<ApiUser> _userManager , toolDbContext _context) : base(_context)
        {
            _userManager = _userManager;
            context = _context;
        }


        public async Task<bool> CheckPasswordAsync(ApiUser user, string password)
        {
            return await userManager.CheckPasswordAsync(user, password);
        }

        public async Task<bool> CreateUserAsync(ApiUser user, string password )
        {
           await userManager.CreateAsync(user, password);
            return true;
        }

        public async Task DeleteAsync(int id)
        {
            var user = await GetAsync(id);
            if (user != null)
                await userManager.DeleteAsync(user);
        }

        public async Task<bool> ExistsAsync(int id)
        {
            var user = await GetAsync(id);
            return user != null;
        }

        public async Task<IEnumerable<ApiUser>> GetAllAsync()
        {
            return userManager.Users;
        }

        public async Task<ApiUser> GetAsync(int id)
        {
            return await userManager.FindByIdAsync(id.ToString());
        }

        public async Task<ApiUser> SearchByEmailAsync(string email)
        {
            return await userManager.FindByEmailAsync(email);
        }

        public async Task UpdateAsync(ApiUser entity)
        {
            await userManager.UpdateAsync(entity);
        }
    }
}
