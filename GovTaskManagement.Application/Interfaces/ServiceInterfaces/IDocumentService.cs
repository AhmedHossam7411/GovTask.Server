namespace GovTaskManagement.Application.Services
{
    public interface IDocumentService
    {
        Task<bool> createDocument();
        Task<bool> updateDocument();
        Task<bool> deleteDocument();
    }
}