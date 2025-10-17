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
    public class ApiUserRepository : GenericRepository<ApiUser> , IApiUserRepository
    {
        private readonly UserManager<ApiUser> _userManager;
        private readonly ToolDbContext _context;
        
        public ApiUserRepository(UserManager<ApiUser> userManager , ToolDbContext context) : base(context)
        {
            _userManager = userManager;
            _context = context;
            
        }

        public async Task<bool> CheckPasswordAsync(ApiUser user, string password)
        {
            return await _userManager.CheckPasswordAsync(user, password);
        }

        public async Task<IdentityResult> CreateUserAsync(ApiUser user, string password )
        {
            try
            {
           return await _userManager.CreateAsync(user, password);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            
        }

        public async Task<bool> DeleteUserAsync(ApiUser user)
        {
           
            var deleted = await _userManager.DeleteAsync(user);
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

        public async Task<ApiUser> SearchByEmailAsync(string email)
        {
            return await _userManager.FindByEmailAsync(email);
        }

        
    }
}
