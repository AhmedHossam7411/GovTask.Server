using GovTaskManagement.Application.Interfaces.Repositories;
using GovTaskManagement.Domain.Entities;
using GovTaskManagement.Infrastructure.Data;

namespace GovTaskManagement.Infrastructure.Repositories
{
    public class BehaviorRepository : GenericRepository<BehaviorWindow,int> , IBehaviorRepository
    {
        public BehaviorRepository(ToolDbContext context) : base(context)
        {
        }
    }
}
