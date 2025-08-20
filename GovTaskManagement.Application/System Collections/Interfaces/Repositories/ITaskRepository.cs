using GovTaskManagement.Domain.Entities;

namespace GovTaskManagement.Application.Interfaces.Repositories
{
    public interface ITaskRepository : IGenericRepository<TaskEntity>
    {
        Task<IEnumerable<TaskEntity>> GetTasksByDepartmentId(int departmentId);
        Task<TaskEntity> GetTaskByDocumentId(int documentId);
        Task<IEnumerable<TaskEntity>> GetTasksByUserId(int userId);

        
        
        
    }
}