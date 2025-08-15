using GovTaskManagement.Domain.Entities;

namespace GovTaskManagement.Application.Services
{
    public interface IDepartmentService
    {
        //Task<bool> createDepartment();
        //Task<bool> updateDepartment();
        //Task<bool> deleteDepartment();

        Task<DepartmentEntity?> GetDepartmentByTaskId(int taskId);
        
        Task<DepartmentEntity?> GetDepartmentByUserId(int userId);
    }
}