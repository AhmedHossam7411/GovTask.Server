using GovTaskManagement.Domain.Entities;

namespace GovTaskManagement.Application.Interfaces.ServiceInterfaces
{
    public interface IDepartmentService
    {
        Task<DepartmentEntity> CreateDepartment(DepartmentEntity entity);
        Task<DepartmentEntity> UpdateDepartment(DepartmentEntity entity);
        Task<bool> DeleteDepartment(string deptId);
        Task<DepartmentEntity> GetDepartmentById(string departmentId);
        Task<IEnumerable<DepartmentEntity>> GetAllDepartments();
        Task<DepartmentEntity?> GetDepartmentByTaskId(int taskId);
        Task<DepartmentEntity?> GetDepartmentByUserId(string userId);
    }
}