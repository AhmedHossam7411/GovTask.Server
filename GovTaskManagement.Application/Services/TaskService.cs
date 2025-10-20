
using GovTaskManagement.Application.Dtos;
using GovTaskManagement.Application.Interfaces.Repositories;
using GovTaskManagement.Application.Interfaces.ServiceInterfaces;
using GovTaskManagement.Application.Mappers;

namespace GovTaskManagement.Application.Services
{
    public class TaskService : ITaskService
    {
        private IUnitOfWork UnitOfWork;
        private ITaskRepository TaskRepository;
        
        public TaskService(IUnitOfWork _unitOfWork, ITaskRepository _taskRepository)
        {
            UnitOfWork = _unitOfWork;
            TaskRepository = _taskRepository;
            
        }
        public async Task<TaskDto> CreateTask(TaskDto dto , string creatorId)
        {
            var entity = dto.ToEntity();
            var createdEntity = await UnitOfWork.TasksRepository.CreateAsync(entity);
            createdEntity.creatorId = creatorId;
            try
            {
            await UnitOfWork.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            return createdEntity.ToDto();
        }


        public async Task<bool> DeleteTask(int taskId)
        {
            var documents = await UnitOfWork.DocumentRepository.GetDocumentsByTaskId(taskId);
            if (documents != null)
            {
                foreach (var doc in documents)
                {
                    await UnitOfWork.DocumentRepository.DeleteAsync(doc.Id);
                }
            }

            var result = await UnitOfWork.TasksRepository.DeleteAsync(taskId);
            if (result)
            {
                try
                {
                await UnitOfWork.SaveChangesAsync();

                }
                catch (Exception ex)
                {
                    
                    throw;
                }
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<TaskDto>> GetAllTasks()
        {
            var entities = await UnitOfWork.TasksRepository.GetAllAsync();
            return entities.ToDto();
        }

        public async Task<TaskDto> GetTaskByDocumentId(int TaskId)
        {

            var task = await UnitOfWork.TasksRepository.GetTaskByDocumentId(TaskId);
            return task.ToDto();
        }

        public async Task<TaskDto> GetTaskById(int taskId)
        {
            var task = await UnitOfWork.TasksRepository.GetAsync(taskId);
            return task.ToDto();
        }

        public async Task<TaskDto> UpdateTask(TaskDto dto)
        {
            var entity = dto.ToEntity();
            var updatedEntity = await UnitOfWork.TasksRepository.UpdateAsync(entity);
            await UnitOfWork.SaveChangesAsync();
            return updatedEntity.ToDto();
        }

        public async Task<IEnumerable<TaskDto>> GetTasksByDepartmentId(int departmentId)
        {
            var tasks = await UnitOfWork.TasksRepository.GetTasksByDepartmentId(departmentId);
            return tasks.ToDto();
        }
        public async Task<IEnumerable<TaskDto>> GetTasksByCreatorId(string creatorId)
        {
            var tasks = await UnitOfWork.TasksRepository.GetTasksByCreatorId(creatorId);
            return tasks.ToDto();

        }
    }
}
