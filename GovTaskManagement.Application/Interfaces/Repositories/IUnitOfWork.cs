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

        Task<int> SaveChangesAsync();  // Method to save changes asynchronously
    }
}
