using GovTaskManagement.Application.Interfaces.Repositories;
using GovTaskManagement.Domain.Entities;
using GovTaskManagement.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace GovTaskManagement.Infrastructure.Repositories
{
    public class RefreshTokenRepository : IRefreshTokenRepository
    {
        private ToolDbContext _context;
        public RefreshTokenRepository(ToolDbContext context)
        {
            _context = context;
        
        }
        public async Task AddAsync(RefreshToken token)
        {
            await _context.RefreshTokens.AddAsync(token);
        }
        public async Task<RefreshToken?> GetByTokenAsync(string token)
        {
            return await _context.RefreshTokens
                .FirstOrDefaultAsync(x => x.Token == token);
        }
    }

}

