using System.Collections;

namespace GovTaskManagement.Application.Interfaces.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetAsync(int id );
        Task<IEnumerable<T>> GetAllAsync();
        T UpdateAsync (T entity);  
        Task  DeleteAsync (int id); 
        Task<bool> ExistsAsync (int id);
    }
   
}
