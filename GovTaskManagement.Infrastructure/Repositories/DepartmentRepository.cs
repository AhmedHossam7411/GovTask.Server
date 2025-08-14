using GovTaskManagement.Application.Interfaces.Repositories;
using GovTaskManagement.Domain.Entities;
using GovTaskManagement.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace GovTaskManagement.Infrastructure.Repositories
{
    public class DepartmentRepository : GenericRepository<DepartmentEntity>, IDepartmentRepository

    {
            private readonly toolDbContext context;

            public DepartmentRepository(toolDbContext _context) : base(_context)
            {
                context = _context;

            }

        public async Task<DepartmentEntity> GetDepartmentByDocumentId(int documentId)
        {
            var department = await context.Departments.Include(dep => dep.Documents)
                 .FirstOrDefaultAsync(dep => dep.Documents.Any(doc => doc.documentId == documentId));
            return department != null ? department : null;
        }

        public async Task<DepartmentEntity> GetDepartmentByTaskId(int taskId)
        {
            var department = await context.Departments.Include(dep => dep.tasks)
                .FirstOrDefaultAsync(dep => dep.tasks.Any(task => task.taskId == taskId));
            return department != null ? department : null;
        }

        public async Task<DepartmentEntity> GetDepartmentByUserId(int userId)
        {
            var department = await context.Departments.Include(dep => dep.Users)
                .FirstOrDefaultAsync(dep => dep.Users.Any(user => user.userId == userId));
            return department != null ? department : null;
        }
    }
}
