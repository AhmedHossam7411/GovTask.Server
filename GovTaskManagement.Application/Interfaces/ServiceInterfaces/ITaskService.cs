namespace GovTaskManagement.Application.Services
{
    public interface ITaskService
    {
        Task<bool> createTask();
        Task<bool> updateTask();
        Task<bool> deleteTask();
    }
}