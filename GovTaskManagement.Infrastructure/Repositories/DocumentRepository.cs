using GovTaskManagement.Application.Interfaces.Repositories;
using GovTaskManagement.Domain.Entities;
using GovTaskManagement.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;



namespace GovTaskManagement.Infrastructure.Repositories
{
    public class DocumentRepository :  GenericRepository<DocumentEntity> , IDocumentRepository
    {
        private readonly toolDbContext context;
        

        public DocumentRepository(toolDbContext _context) : base(_context) 
        {
            context = _context;
            
        }

        public async Task<IEnumerable<DocumentEntity>?> GetDocumentsByTaskId(int taskID)
        {
            var task = await context.Tasks.Include(t => t.Documents)
                .FirstOrDefaultAsync(t => t.Id == taskID);
            return task?.Documents;
        }
        //public async Task<IEnumerable<DocumentEntity>?> GetDocumentsByDepartmentId(int departmentId)
        //{
        //    var department = await context.Departments.Include(d => d.Documents)
        //        .FirstOrDefaultAsync(d => d.Id == departmentId);
        //    return department?.Documents;
        //}
        //public async Task<IEnumerable<DocumentEntity>?> GetDocumentsByUserId(int userId)
        //{
        //    var user = await context.Users.Include(u => u.Documents)
        //        .FirstOrDefaultAsync(u => u.Id == userId);
        //    return user?.Documents;
        //}
       
    }

}

