using GovTaskManagement.Domain.Entities;

namespace GovTaskManagement.Application.Interfaces.Repositories
{
    public interface IDepartmentRepository : IGenericRepository<DepartmentEntity, int>
    {
        Task<DepartmentEntity> GetDepartmentByTaskId(int taskId);
        
        Task<DepartmentEntity> GetDepartmentByUserId(string userId);
    }
}
