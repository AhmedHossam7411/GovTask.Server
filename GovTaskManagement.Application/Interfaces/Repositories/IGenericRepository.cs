using System.Collections;

namespace GovTaskManagement.Application.Interfaces.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> CreateAsync(T entity);
        Task<T> GetAsync(int id );
        Task<IEnumerable<T>> GetAllAsync();
        Task <T> UpdateAsync (T entity);  
        Task <bool> DeleteAsync (int id); 
        Task<bool> ExistsAsync (int id);
    }
   
}
