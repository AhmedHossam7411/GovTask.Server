using GovTaskManagement.Domain.Entities;

namespace GovTaskManagement.Application.Interfaces.Repositories
{
    public interface IDepartmentRepository : IGenericRepository<DepartmentEntity>
    {
        Task<DepartmentEntity> GetDepartmentByTaskId(int taskId);
        
        Task<DepartmentEntity> GetDepartmentByUserId(int userId);
    }
}
