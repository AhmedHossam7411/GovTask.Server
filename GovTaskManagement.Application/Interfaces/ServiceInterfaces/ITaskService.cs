using GovTaskManagement.Application.Dtos;
using GovTaskManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace GovTaskManagement.Application.Interfaces.ServiceInterfaces
{
    public interface ITaskService
    {
        Task <TaskDto> CreateTask(TaskDto entity , string creatorId);
        
        Task<bool> DeleteTask(int taskId);

        Task<TaskDto> UpdateTask(TaskDto entity);
        Task <TaskDto> GetTaskById(int taskId);
        Task<IEnumerable<TaskDto>> GetAllTasks();
        Task<TaskDto> GetTaskByDocumentId(int documentId);
        Task <IEnumerable<TaskDto>> GetTasksByDepartmentId(int departmentId);
        Task<IEnumerable<TaskDto>> GetTasksByCreatorId(string creatorId);
    }
}