using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GovTaskManagement.Application.Interfaces.Repositories
{
    public interface IUnitOfWork : IDisposable // repository wrapper interface 
    {
        public ITaskRepository TasksRepository { get; } 
        public IDocumentRepository DocumentRepository { get; }
        public IDepartmentRepository DepartmentRepository { get; }
        public IApiUserRepository ApiUserRepository { get; }
        public IUserRepository UserRepository { get; }
        public IRefreshTokenRepository RefreshTokenRepository { get; }
        public IBehaviorRepository BehaviorRepository { get; }
        public ISecurityAlertRepository SecurityAlertRepository { get; }
        Task<int> SaveChangesAsync();
    }
}
