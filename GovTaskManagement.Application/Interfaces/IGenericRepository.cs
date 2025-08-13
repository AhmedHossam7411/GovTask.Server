using System.Collections;

namespace GovTaskManagement.Application.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetAsync();
        Task<IEnumerable<T>> GetAllAsync();
        Task AddAsync(T entity);
        Task UpdateAsync (T entity);  
        Task  DeleteAsync (int id); 
        Task<bool> ExistsAsync (int id);
    }
   
}
