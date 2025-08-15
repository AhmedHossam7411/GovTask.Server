using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GovTaskManagement.Domain.Entities
{
    public class TaskEntity
    {
        public int Id { get; set; }
        public string TaskName { get; set; }
        public string TaskDescription { get; set; }
        public DateTime TaskDueDate { get; set; }

        public int DepartmentId { get; set; }          // FK
        public DepartmentEntity Department { get; set; }  // Navigation

        public List<DocumentEntity> Documents { get; set; } = new List<DocumentEntity>();

        public ICollection<ApiUser> Users { get; set; } = new List<ApiUser>();


    }
}
