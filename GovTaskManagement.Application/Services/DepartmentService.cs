using GovTaskManagement.Application.Interfaces.Repositories;
using GovTaskManagement.Application.Interfaces.ServiceInterfaces;
using GovTaskManagement.Domain.Entities;
using System.Threading.Tasks;

namespace GovTaskManagement.Application.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository Repository;
        private readonly IUnitOfWork UnitOfWork;
        public DepartmentService(IDepartmentRepository _departmentRepository , IUnitOfWork _unitOfWork) 
        { 
          Repository = _departmentRepository;
            UnitOfWork = _unitOfWork;
        }
        public async Task<IEnumerable<DepartmentEntity>> GetAllDepartments()
        {
            var entities = await UnitOfWork.DepartmentRepository.GetAllAsync();
            return entities;
        }
        public async Task<DepartmentEntity> UpdateDepartment(DepartmentEntity entity)
        {
            
            var updatedEntity = await UnitOfWork.DepartmentRepository.UpdateAsync(entity);
            await UnitOfWork.SaveChangesAsync();
            return updatedEntity;
        }
        public async Task<bool> DeleteDepartment(int departmentId)
        {

            var result = await UnitOfWork.DepartmentRepository.DeleteAsync(departmentId);
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
        public async Task<DepartmentEntity> CreateDepartment(DepartmentEntity entity)
        {
            
            var createdEntity = await UnitOfWork.DepartmentRepository.CreateAsync(entity);
            await UnitOfWork.SaveChangesAsync();
            return createdEntity;
        }
        public async Task<DepartmentEntity> GetDepartmentById(int departmentId)
        {
            var dept = await UnitOfWork.DepartmentRepository.GetAsync(departmentId);
            return dept;
        }

        public async Task<DepartmentEntity?> GetDepartmentByTaskId(int taskId)
        {
            var dept = await UnitOfWork.DepartmentRepository.GetDepartmentByTaskId(taskId);
            return dept;
        }

        public async Task<DepartmentEntity?> GetDepartmentByUserId(string userId)
        {
            var dept = await UnitOfWork.DepartmentRepository.GetDepartmentByUserId(userId);
            return dept;
        }
    }
}
