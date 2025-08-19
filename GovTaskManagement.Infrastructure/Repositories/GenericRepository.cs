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
        private readonly toolDbContext context;
        
        public GenericRepository(toolDbContext _context )
        {
            context = _context;
            
        }

        public virtual async Task<T> CreateAsync(T entity)
        {
            await context.Set<T>().AddAsync(entity);
            
            return entity;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await GetAsync(id);
            if (entity != null)
            {
                context.Set<T>().Remove(entity);
                
                return true;
            }
            return false;
        }
        public virtual async Task<bool> ExistsAsync(int id)
        {
            var exists = await context.Set<T>().FindAsync(id) != null;
            
            return exists;
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            var getAll = await context.Set<T>().ToListAsync();
            
            return getAll;
        }

        public virtual async Task<T?> GetAsync(int id)
        {
            var get = await context.Set<T>().FindAsync(id);
            
            return get;
        }

        public virtual async Task<T> UpdateAsync(T entity)
        {
            var updated = context.Set<T>().Update(entity);
            
            return updated.Entity;
        }
    }
}

