using GovTaskManagement.Domain.Entities;

namespace GovTaskManagement.Application.Interfaces
{
    public interface IDepartmentRepository : IGenericRepository<Department>
    {
        Task<IEnumerable<Department>> GetDepartmentsByTaskId(int taskId);
        Task<IEnumerable<Department>> GetDepartmentsByDocumentId(int documentId);
        Task<IEnumerable<Department>> GetDepartmentsByUserId(int userId);
    }
}
