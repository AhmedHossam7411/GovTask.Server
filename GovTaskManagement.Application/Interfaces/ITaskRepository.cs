using GovTaskManagement.Domain.Entities;

namespace GovTaskManagement.Application.Interfaces
{
    public interface ITaskRepository : IGenericRepository<TaskEntity>
    {
        Task<IEnumerable<TaskEntity>> GetTasksByDepartmentId(int departmentId);
        Task<IEnumerable<TaskEntity>> GetTasksByDocumentId(int documentId);
        Task<IEnumerable<TaskEntity>> GetTasksByUserId(int userId);

    }
}