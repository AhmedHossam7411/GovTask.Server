using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GovTaskManagement.Application.Interfaces
{
    internal interface IUnitOfWork : IDisposable // repository wrapper interface 
    {
        public ITaskRepository TasksRepository { get; } 
        public IDocumentRepository DocumentRespository { get; }
        public IDepartmentRepository DepartmentRepository { get; }

        Task<int> SaveChangesAsync();  // Method to save changes asynchronously
    }
}
