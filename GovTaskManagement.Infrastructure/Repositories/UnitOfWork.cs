using GovTaskManagement.Application.Interfaces.Repositories;
using GovTaskManagement.Infrastructure.Data;

namespace GovTaskManagement.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly toolDbContext _context;
        public ITaskRepository TasksRepository { get; }

        public IDepartmentRepository DepartmentRepository { get; }

        public IDocumentRepository DocumentRepository { get; }

        public IUserRepository UserRepository {  get; }

        public UnitOfWork(
           toolDbContext context,
           ITaskRepository taskRepository,
           IDocumentRepository documentRepository,
           IDepartmentRepository departmentRepository)
        {
            _context = context;
            TasksRepository = taskRepository;
            DocumentRepository = documentRepository;
            DepartmentRepository = departmentRepository;
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
