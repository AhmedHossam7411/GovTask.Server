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
        public IRefreshTokenRepository RefreshTokenRepository { get; }
        public IBehaviorRepository BehaviorRepository { get; }
        public ISecurityAlertRepository SecurityAlertRepository { get; }

        public UnitOfWork(
           ToolDbContext context,
           ITaskRepository taskRepository,
           IDocumentRepository documentRepository,
           IDepartmentRepository departmentRepository,
           IUserRepository userRepository,
           IApiUserRepository apiUserRepository,
           IRefreshTokenRepository refreshTokenRepository,
           IBehaviorRepository behaviorRepository,
           ISecurityAlertRepository securityAlertRepository
            )
        {
            _context = context;
            TasksRepository = taskRepository;
            DocumentRepository = documentRepository;
            DepartmentRepository = departmentRepository;
            UserRepository = userRepository;
            ApiUserRepository = apiUserRepository;
            RefreshTokenRepository = refreshTokenRepository;
            BehaviorRepository = behaviorRepository;
            SecurityAlertRepository = securityAlertRepository;
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
