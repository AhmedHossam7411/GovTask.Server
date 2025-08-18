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

        public ApiUser ApiUser { get; set; }  // Navigation property to User associated with the department
        public List<ApiUser> Users { get; set; }  // Navigation property to Users associated with the department

        

        public TaskEntity TaskEntity { get; set; }
        public List<TaskEntity> Tasks { get; set; }

    }
}
