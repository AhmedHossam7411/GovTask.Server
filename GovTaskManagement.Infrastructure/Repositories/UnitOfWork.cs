using GovTaskManagement.Application.Interfaces.Repositories;
using GovTaskManagement.Domain.Entities;
using GovTaskManagement.Infrastructure.Data;

namespace GovTaskManagement.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ToolDbContext _context;
        
        public ITaskRepository TasksRepository { get; }

        public IDepartmentRepository DepartmentRepository { get; }

        public IDocumentRepository DocumentRepository { get; }

        public IUserRepository UserRepository { get; }

        public IApiUserRepository ApiUserRepository {  get; }

        public UnitOfWork(
           ToolDbContext context,
           ITaskRepository taskRepository,
           IDocumentRepository documentRepository,
           IDepartmentRepository departmentRepository,
            IUserRepository userRepository,
            IApiUserRepository apiUserRepository
            )
        {
            _context = context;
            TasksRepository = taskRepository;
            DocumentRepository = documentRepository;
            DepartmentRepository = departmentRepository;
            UserRepository = userRepository;
            ApiUserRepository = apiUserRepository;

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
