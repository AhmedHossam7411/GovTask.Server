using GovTaskManagement.Application.System_Collections.Dtos;
using GovTaskManagement.Domain.Entities;

namespace GovTaskManagement.Application.Services
{
    public interface ITaskService
    {
        Task <TaskDto> CreateTask(TaskDto entity);
        
        Task<bool> DeleteTask(int taskId);

        Task<TaskDto> UpdateTask(TaskDto entity);
        Task <TaskDto> GetTaskById(int taskId);
        Task<IEnumerable<TaskDto>> GetAllTasks();
        Task<TaskDto> GetTaskByDocumentId(int documentId);
        Task <IEnumerable<TaskDto>> GetTasksByDepartmentId(int departmentId);
    }
}