using GovTaskManagement.Domain.Entities;

namespace GovTaskManagement.Application.Services
{
    public interface ITaskService
    {
        Task<bool> CreateTask();
        Task<bool> UpdateTask();
        Task<bool> DeleteTask();

        Task <TaskEntity> GetTaskById(int  taskId);
        Task<IEnumerable<TaskEntity>> GetAllTasks(int taskId);
    }
}