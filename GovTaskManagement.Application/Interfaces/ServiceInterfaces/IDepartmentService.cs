namespace GovTaskManagement.Application.Services
{
    public interface IDepartmentService
    {
        Task<bool> createDepartment();
        Task<bool> updateDepartment();
        Task<bool> deleteDepartment();

    }
}