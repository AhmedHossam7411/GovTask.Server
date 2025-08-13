using GovTaskManagement.Application.Interfaces.Repositories;
using GovTaskManagement.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GovTaskManagement.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManager<ApiUser> _userManager;

        public UserRepository(UserManager<ApiUser> userManager)
        {
            _userManager = userManager;
        }


        public async Task<bool> CheckPasswordAsync(ApiUser user, string password)
        {
            return await _userManager.CheckPasswordAsync(user, password);
        }

        public async Task<bool> CreateUserAsync(ApiUser user, string password )
        {
           await _userManager.CreateAsync(user, password);
            return true;
        }

        public async Task DeleteAsync(int id)
        {
            var user = await GetAsync(id);
            if (user != null)
                await _userManager.DeleteAsync(user);
        }

        public async Task<bool> ExistsAsync(int id)
        {
            var user = await GetAsync(id);
            return user != null;
        }

        public async Task<IEnumerable<ApiUser>> GetAllAsync()
        {
            return _userManager.Users;
        }

        public async Task<ApiUser> GetAsync(int id)
        {
            return await _userManager.FindByIdAsync(id.ToString());
        }

        public async Task<ApiUser> SearchByEmailAsync(string email)
        {
            return await _userManager.FindByEmailAsync(email);
        }

        public async Task UpdateAsync(ApiUser entity)
        {
            await _userManager.UpdateAsync(entity);
        }
    }
}
