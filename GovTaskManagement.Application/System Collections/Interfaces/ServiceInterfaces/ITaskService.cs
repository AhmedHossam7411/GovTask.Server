using GovTaskManagement.Domain.Entities;

namespace GovTaskManagement.Application.Services
{
    public interface ITaskService
    {
        Task <TaskEntity> CreateTask(TaskEntity entity);
        
        Task<bool> DeleteTask(int taskId);

        Task<TaskEntity> UpdateTask(TaskEntity entity);
        Task <TaskEntity> GetTaskById(int taskId);
        Task<IEnumerable<TaskEntity>> GetAllTasks();
        Task<TaskEntity> GetTaskByDocumentId(int documentId);
        Task <IEnumerable<TaskEntity>> GetTasksByDepartmentId(int departmentId);
    }
}