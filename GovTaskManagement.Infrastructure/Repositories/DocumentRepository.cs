using GovTaskManagement.Application.Interfaces.Repositories;
using GovTaskManagement.Domain.Entities;
using GovTaskManagement.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;



namespace GovTaskManagement.Infrastructure.Repositories
{
    public class DocumentRepository :  GenericRepository<DocumentEntity> , IDocumentRepository
    {
<<<<<<< Updated upstream
        private readonly ToolDbContext _context;
        public DocumentRepository(ToolDbContext context) : base(context) { _context = context; }
       

        public async Task<IEnumerable<DocumentEntity>?> GetDocumentsByTaskId(int taskId)
        {
            var task = await _context.Tasks.Include(t => t.Documents)
                .FirstOrDefaultAsync(t => t.Id == taskId);
=======

        public DocumentRepository(ToolDbContext _context) : base(_context) { }
      
        public async Task<IEnumerable<DocumentEntity>?> GetDocumentsByTaskId(int taskID)
        {
            var task = await context.Tasks.Include(t => t.Documents)
                .FirstOrDefaultAsync(t => t.Id == taskID);
>>>>>>> Stashed changes
            return task?.Documents;
        }
       
       
    }

}

