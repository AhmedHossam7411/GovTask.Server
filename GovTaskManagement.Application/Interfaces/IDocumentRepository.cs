using GovTaskManagement.Domain.Entities;
using System.Reflection.Metadata;

namespace GovTaskManagement.Application.Interfaces
{
    public interface IDocumentRepository : IGenericRepository<DocumentEntity>
    {
        Task<IEnumerable<DocumentEntity>> GetDocumentsByTaskId(int taskId);
        Task<IEnumerable<DocumentEntity>> GetDocumentsByDepartmentId(int departmentId);
        Task<IEnumerable<DocumentEntity>> GetDocumentsByUserId(int userId);
    }
}