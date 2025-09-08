using GovTaskManagement.Application.Dtos;
using GovTaskManagement.Application.Interfaces.Repositories;
using GovTaskManagement.Application.Interfaces.ServiceInterfaces;
using GovTaskManagement.Application.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace GovTaskManagement.Application.Services
{
    public class DocumentService : IDocumentService
    {

    private readonly IUnitOfWork _unitOfWork;
    private readonly IDocumentRepository _documentRepository;

    public DocumentService(IUnitOfWork unitOfWork, IDocumentRepository documentRepository)
    {
        _unitOfWork = unitOfWork;
        _documentRepository = documentRepository;

    }
        public async Task<DocumentDto> CreateDocument(DocumentDto dto)
        {
            var entity = dto.ToEntity();
            var document = await _unitOfWork.DocumentRepository.CreateAsync(entity);
            await _unitOfWork.SaveChangesAsync();
            return entity.ToDto();
        }
        public async Task<bool> DeleteDocument(int documentId)
        {
            var result = await _unitOfWork.DocumentRepository.DeleteAsync(documentId);
            if (result)
            {
                await _unitOfWork.SaveChangesAsync();
                return true;
            }
            return false;
        }
        public async Task<DocumentDto> UpdateDocument(DocumentDto dto)
        {
            var entity = dto.ToEntity();
            var updatedDocument = await _unitOfWork.DocumentRepository.UpdateAsync(entity);
            await _unitOfWork.SaveChangesAsync();
            return updatedDocument.ToDto();
        }
        public async Task<DocumentDto> GetDocumentById(int documentId)
        {
            var document = await _unitOfWork.DocumentRepository.GetAsync(documentId);
            return document.ToDto();
        }
        public async Task<IEnumerable<DocumentDto>> GetAllDocuments()
        {
            var documents = await _unitOfWork.DocumentRepository.GetAllAsync();
            return documents.ToDto();
        }
        public async Task<IEnumerable<DocumentDto>> GetDocumentsByTaskId(int taskId)
        {
            var documents = await _unitOfWork.DocumentRepository.GetDocumentsByTaskId(taskId);
            return documents.ToDto();
        }
    }
}
