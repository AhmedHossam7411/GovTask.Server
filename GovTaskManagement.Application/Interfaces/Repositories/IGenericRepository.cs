using System.Collections;

namespace GovTaskManagement.Application.Interfaces.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> CreateAsync(T entity);
        Task<T> GetAsync(string id );
        Task<IEnumerable<T>> GetAllAsync();
        Task <T> UpdateAsync (T entity);  
        Task <bool> DeleteAsync (string id); 
        Task<bool> ExistsAsync (string id);
    }
   
}
