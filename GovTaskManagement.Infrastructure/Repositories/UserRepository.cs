using GovTaskManagement.Application.Interfaces.Repositories;
using GovTaskManagement.Domain.Entities;
using GovTaskManagement.Infrastructure.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
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
        private readonly DbContext context;
        
        public UserRepository(UserManager<ApiUser> _userManager , ToolDbContext _context) : base(_context)
        {
            userManager = _userManager;
            context = _context;
            
        }


        public async Task<bool> CheckPasswordAsync(ApiUser user, string password)
        {
            return await userManager.CheckPasswordAsync(user, password);
        }

        public async Task<IdentityResult> CreateUserAsync(ApiUser user, string password )
        {
           return await userManager.CreateAsync(user, password);
            
        }

        public async Task<bool> DeleteUserAsync(ApiUser user)
        {
           
            var deleted = await userManager.DeleteAsync(user);
            if (deleted.Succeeded)
            { 
                return true;
            }
            return false;
        }

        public override async Task<bool> ExistsAsync(int id)
        {
            var user = await GetAsync(id);
            return user != null;
        }

        public override async Task<IEnumerable<ApiUser>> GetAllAsync()
        {
            return userManager.Users;
        }

        public override async Task<ApiUser> GetAsync(int id)
        {
            return await userManager.FindByIdAsync(id.ToString());
        }

        public async Task<ApiUser> SearchByEmailAsync(string email)
        {
            return await userManager.FindByEmailAsync(email);
        }

        public async Task<string> UpdateUserAsync(ApiUser entity)
        {
            await userManager.UpdateAsync(entity);
            return entity.ConcurrencyStamp;
        }
    }
}
