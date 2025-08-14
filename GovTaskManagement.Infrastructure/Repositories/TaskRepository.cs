using GovTaskManagement.Application.Interfaces;
using GovTaskManagement.Application.Interfaces.Repositories;
using GovTaskManagement.Domain.Entities;
using GovTaskManagement.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace GovTaskManagement.Infrastructure.Repositories
{
    public class TaskRepository : GenericRepository<TaskEntity>, ITaskRepository
    {
        private readonly toolDbContext context;

        public TaskRepository(toolDbContext _context) : base(_context)
        {
            context = _context;

        }

        public async Task<IEnumerable<TaskEntity>?> GetTasksByDepartmentId(int departmentId)
        {
            var department = await context.Departments.Include(d => d.tasks)
                .FirstOrDefaultAsync(d => d.departmentId == departmentId);
            return department?.tasks;
        }

        public async Task<TaskEntity?> GetTaskByDocumentId(int documentId)
        {
            return await context.Tasks.Include(t => t.Documents)
                .FirstOrDefaultAsync(t => t.Documents.Any(d => d.documentId == documentId));

        }

        public async Task<IEnumerable<TaskEntity>> GetTasksByUserId(int userId)
        {
            var tasks = await context.Tasks.Include(t => t.Users)
                .Where(u => u.Users.Any(u => u.userId == userId))
                .ToListAsync();
            return tasks;
        }
    }
}
