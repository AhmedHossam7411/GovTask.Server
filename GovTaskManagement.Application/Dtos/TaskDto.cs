using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GovTaskManagement.Application.Dtos
{
    public class TaskDto
    {
          public int Id { get; set; }
          public string Name { get; set; }
          public string Description { get; set; }
          public DateTime DueDate { get; set; }
          public int? DepartmentId { get; set; }
        
    }
}
