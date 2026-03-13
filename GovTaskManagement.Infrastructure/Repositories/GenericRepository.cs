using GovTaskManagement.Application.Interfaces.Repositories;
using GovTaskManagement.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace GovTaskManagement.Infrastructure.Repositories
{
    public class GenericRepository<T, TKey> : IGenericRepository<T, TKey> where T : class

    {
        protected readonly ToolDbContext _context;
        
        public GenericRepository(ToolDbContext _context )
        {
            this._context = _context;
            
        }

        public virtual async Task<T> CreateAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            
            return entity;
        }

        public async Task<bool> DeleteAsync(TKey id)
        {
            var entity = await GetAsync(id);
            if (entity != null)
            {
                _context.Set<T>().Remove(entity);
                
                return true;
            }
            return false;
        }
        public virtual async Task<bool> ExistsAsync(TKey id)
        {
            var exists = await _context.Set<T>().FindAsync(id) != null;
            
            return exists;
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            var getAll = await _context.Set<T>().ToListAsync();
            
            return getAll;
        }

        public virtual async Task<T> GetAsync(TKey id)
        {
            var get = await _context.Set<T>().FindAsync(id);
            
            return get;
        }

        public virtual async Task<T> UpdateAsync(T entity)
        {
            var updated = _context.Set<T>().Update(entity);
            return updated.Entity;
        }
    }
}

