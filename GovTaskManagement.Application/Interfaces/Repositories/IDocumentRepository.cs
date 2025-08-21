using GovTaskManagement.Application.Dtos;
using GovTaskManagement.Domain.Entities;
using System.Reflection.Metadata;

namespace GovTaskManagement.Application.Interfaces.Repositories
{
    public interface IDocumentRepository : IGenericRepository<DocumentEntity>
    {
        Task<IEnumerable<DocumentEntity>> GetDocumentsByTaskId(int taskId);    
        
    }
}