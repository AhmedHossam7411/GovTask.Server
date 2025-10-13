using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GovTaskManagement.Domain.Entities
{
    public class DepartmentEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ApiUser? ApiUser { get; set; }  
        public List<ApiUser>? Users { get; set; }  
        
        public TaskEntity? TaskEntity { get; set; }
        public List<TaskEntity>? Tasks { get; set; }

    }
}
