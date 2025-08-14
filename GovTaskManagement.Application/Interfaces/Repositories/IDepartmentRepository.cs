using GovTaskManagement.Domain.Entities;

namespace GovTaskManagement.Application.Interfaces.Repositories
{
    public interface IDepartmentRepository : IGenericRepository<DepartmentEntity>
    {
        Task<IEnumerable<DepartmentEntity>> GetDepartmentsByTaskId(int taskId);
        Task<IEnumerable<DepartmentEntity>> GetDepartmentsByDocumentId(int documentId);
        Task<IEnumerable<DepartmentEntity>> GetDepartmentsByUserId(int userId);
    }
}
