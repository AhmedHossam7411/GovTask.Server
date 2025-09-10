using GovTaskManagement.Application.Interfaces.Repositories;
using GovTaskManagement.Domain.Entities;
using GovTaskManagement.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;



namespace GovTaskManagement.Infrastructure.Repositories
{
    public class DocumentRepository :  GenericRepository<DocumentEntity> , IDocumentRepository
    {
        public DocumentRepository(ToolDbContext context) : base(context) 
        {

        }

        public async Task<IEnumerable<DocumentEntity>?> GetDocumentsByTaskId(int taskID)
        {
            var task = await _context.Tasks.Include(t => t.Documents)
                .FirstOrDefaultAsync(t => t.Id == taskID);

            return task?.Documents;
        }
       
       
    }

}

