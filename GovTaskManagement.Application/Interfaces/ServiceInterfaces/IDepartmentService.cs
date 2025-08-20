using GovTaskManagement.Domain.Entities;

namespace GovTaskManagement.Application.Interfaces.ServiceInterfaces
{
    public interface IDepartmentService
    {
        Task<DepartmentEntity> CreateDepartment(DepartmentEntity entity);
        Task<DepartmentEntity> UpdateDepartment(DepartmentEntity entity);
        Task<bool> DeleteDepartment(int deptId);
        Task<DepartmentEntity> GetDepartmentById(int departmentId);
        Task<IEnumerable<DepartmentEntity>> GetAllDepartments();

        Task<DepartmentEntity?> GetDepartmentByTaskId(int taskId);
        
        Task<DepartmentEntity?> GetDepartmentByUserId(int userId);
    }
}