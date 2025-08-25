using GovTaskManagement.Application.Interfaces.Repositories;
using GovTaskManagement.Domain.Entities;
using GovTaskManagement.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;



namespace GovTaskManagement.Infrastructure.Repositories
{
    public class DocumentRepository :  GenericRepository<DocumentEntity> , IDocumentRepository
    {

        private readonly ToolDbContext _context;
        public DocumentRepository(ToolDbContext context) : base(context) { _context = context; }
       
      
        public async Task<IEnumerable<DocumentEntity>?> GetDocumentsByTaskId(int taskID)
        {
            var task = await _context.Tasks.Include(t => t.Documents)
                .FirstOrDefaultAsync(t => t.Id == taskID);

            return task?.Documents;
        }
       
       
    }

}

