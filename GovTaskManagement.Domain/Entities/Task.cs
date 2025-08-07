using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GovTaskManagement.Domain.Entities
{
    internal class Task
    {
        public int taskId { get; set; }
        public string taskName { get; set; }
        public string taskDescription { get; set; }
        public DateTime taskDueDate { get; set; }

        Document Document { get; set; }  // Navigation property to Document associated with the task
        List<Document> Documents { get; set; } 



    }
}
