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
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }

        public ApiUser creator { get; set; }
        public string creatorId { get; set; }
        public int? DepartmentId { get; set; }          
        public DepartmentEntity? Department { get; set; } 

        public List<DocumentEntity> Documents { get; set; } = new List<DocumentEntity>();

        public ICollection<ApiUser> Users { get; set; } = new List<ApiUser>();


    }
}
