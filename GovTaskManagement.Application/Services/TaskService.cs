
using GovTaskManagement.Application.Dtos;
using GovTaskManagement.Application.Interfaces.Repositories;
using GovTaskManagement.Application.Interfaces.ServiceInterfaces;
using GovTaskManagement.Application.Mappers;
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
        public async Task<TaskDto> CreateTask(TaskDto dto)
        {
            var entity = dto.ToEntity();
            var createdEntity = await UnitOfWork.TasksRepository.CreateAsync(entity);
            await UnitOfWork.SaveChangesAsync();
            return createdEntity.ToDto();
        }


        public async Task<bool> DeleteTask(int taskId)
        {

            var result = await UnitOfWork.TasksRepository.DeleteAsync(taskId);
            if (result)
            {
                await UnitOfWork.SaveChangesAsync();
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
    }
}
