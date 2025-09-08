using GovTaskManagement.Application.Interfaces.Repositories;
using GovTaskManagement.Domain.Entities;
using GovTaskManagement.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GovTaskManagement.Infrastructure.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class

    {
        private readonly ToolDbContext _context;
        
        public GenericRepository(ToolDbContext _context )
        {
            this._context = _context;
            
        }

        public virtual async Task<T> CreateAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            
            return entity;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await GetAsync(id);
            if (entity != null)
            {
                _context.Set<T>().Remove(entity);
                
                return true;
            }
            return false;
        }
        public virtual async Task<bool> ExistsAsync(int id)
        {
            var exists = await _context.Set<T>().FindAsync(id) != null;
            
            return exists;
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            var getAll = await _context.Set<T>().ToListAsync();
            
            return getAll;
        }

        public virtual async Task<T> GetAsync(int id)
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

