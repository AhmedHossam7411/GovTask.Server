namespace GovTaskManagement.Application.Interfaces.ServiceInterfaces
{
    public interface IDocumentService
    {
        Task<bool> createDocument();
        Task<bool> updateDocument();
        Task<bool> deleteDocument();
    }
}