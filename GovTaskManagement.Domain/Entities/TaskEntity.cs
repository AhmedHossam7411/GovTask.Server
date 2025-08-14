using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GovTaskManagement.Domain.Entities
{
    public class TaskEntity
    {
        public int taskId { get; set; }
        public string taskName { get; set; }
        public string taskDescription { get; set; }
        public DateTime taskDueDate { get; set; }

        public DocumentEntity Document { get; set; }  // Navigation property to Document associated with the task
        public List<DocumentEntity> Documents { get; set; }

        public ICollection<ApiUser> Users { get; set; } = new List<ApiUser>();


    }
}
