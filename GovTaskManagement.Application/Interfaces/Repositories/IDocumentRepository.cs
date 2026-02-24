using GovTaskManagement.Application.Dtos;
using GovTaskManagement.Domain.Entities;
using System.Reflection.Metadata;

namespace GovTaskManagement.Application.Interfaces.Repositories
{
    public interface IDocumentRepository : IGenericRepository<DocumentEntity, int>
    {
        Task<IEnumerable<DocumentEntity>> GetDocumentsByTaskId(int taskId);    
        
    }
}