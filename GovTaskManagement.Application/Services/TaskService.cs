using GovTaskManagement.Application.Interfaces.Repositories;
using GovTaskManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public async Task<TaskEntity> CreateTask(TaskEntity entity)
        {
            return await UnitOfWork.TasksRepository.CreateAsync(entity);
        }


        public async Task<bool> DeleteTask(int taskId)
        {

            var result = await UnitOfWork.TasksRepository.DeleteAsync(taskId);
            if (result)
                return true;
            return false;
        }

        public Task<IEnumerable<TaskEntity>> GetAllTasks()
        {
            return UnitOfWork.TasksRepository.GetAllAsync();
        }

        public async Task<TaskEntity> GetTaskByDocumentId(int TaskId)
        {
            return await UnitOfWork.TasksRepository.GetTaskByDocumentId(TaskId);
        }

        public async Task<TaskEntity> GetTaskById(int taskId)
        {
            return await UnitOfWork.TasksRepository.GetTaskByTaskId(taskId);
        }

        public async Task<TaskEntity> UpdateTask(TaskEntity entity)
        {
            return await UnitOfWork.TasksRepository.UpdateAsync(entity);
        }

        public Task<IEnumerable<TaskEntity>> GetTasksByDepartmentId(int departmentId)
        {
            return UnitOfWork.TasksRepository.GetTasksByDepartmentId(departmentId);
        }
    }
}
