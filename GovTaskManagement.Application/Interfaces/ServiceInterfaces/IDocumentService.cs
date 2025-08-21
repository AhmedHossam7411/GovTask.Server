using GovTaskManagement.Application.Dtos;

namespace GovTaskManagement.Application.Interfaces.ServiceInterfaces
{
    public interface IDocumentService
    {
        Task<DocumentDto> CreateDocument(DocumentDto dto);
        Task<bool> DeleteDocument(int documentId);
        Task<DocumentDto> UpdateDocument(DocumentDto dto);
        Task<DocumentDto> GetDocumentById(int documentId);
        Task<IEnumerable<DocumentDto>> GetAllDocuments();
        Task <IEnumerable<DocumentDto>> GetDocumentsByTaskId(int taskId);
        
    }
}