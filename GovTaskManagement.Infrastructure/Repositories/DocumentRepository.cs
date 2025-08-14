using GovTaskManagement.Application.Interfaces.Repositories;
using GovTaskManagement.Domain.Entities;
using GovTaskManagement.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;



namespace GovTaskManagement.Infrastructure.Repositories
{
    public class DocumentRepository : IDocumentRepository
    {
        private readonly toolDbContext context;
        
        public DocumentRepository(toolDbContext _context)
        {
             context = _context;
            
        }

        public async Task<IEnumerable<DocumentEntity>?> GetDocumentsByTaskId(int taskID)
        {
            var task = await context.Tasks.Include(t => t.Documents)
                .SingleOrDefaultAsync(t => t.taskId == taskID);  // this throws an exception if there is more than one element Aka Task
            return task?.Documents;
        }
        public async Task<IEnumerable<DocumentEntity>?> GetDocumentsByDepartmentId(int departmentId)
        {
            var department = await context.Departments.Include(d => d.Documents)
                .SingleOrDefaultAsync(d => d.departmentId == departmentId);
            return department?.Documents;
        }
        public async Task<IEnumerable<DocumentEntity>?> GetDocumentsByUserId(int userId)
        {
            var user = await context.Users.Include(u => u.Documents)
                .SingleOrDefaultAsync(u => u.userId == userId);
            return user?.Documents;
        }

        public async Task<DocumentEntity?> GetAsync(int id)
        {
            var document = await context.Documents.FindAsync(id);
            return document;
        }

        public async Task<IEnumerable<DocumentEntity>> GetAllAsync()
        {
            var documents = await context.Documents.ToListAsync();
            return documents;
        }

        public async Task UpdateAsync(DocumentEntity entity)
        {
            context.Documents.Update(entity);
            
        }

        public async Task DeleteAsync(int id)
        {
            var document = await context.Documents.FindAsync(id);
            if(document != null)
            {
                context.Documents.Remove(document);
                
            }
             
        }

        public async Task<bool> ExistsAsync(int id)
        {
            var exists = await context.Documents.AnyAsync(d => d.documentId == id);
            
            return exists ? true : false; 
        }
    }
}
