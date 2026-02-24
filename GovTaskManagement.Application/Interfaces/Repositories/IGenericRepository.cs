using System.Collections;

namespace GovTaskManagement.Application.Interfaces.Repositories
{
    public interface IGenericRepository<T, TKey> where T : class
    {
        Task<T> CreateAsync(T entity);
        Task<T> GetAsync(TKey id );
        Task<IEnumerable<T>> GetAllAsync();
        Task <T> UpdateAsync (T entity);  
        Task <bool> DeleteAsync (TKey id); 
        Task<bool> ExistsAsync (TKey id);
    }
   
}
