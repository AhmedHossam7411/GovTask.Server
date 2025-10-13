using GovTaskManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GovTaskManagement.Application.Dtos
{
    public class TaskDto
    {
          public string Name { get; set; }
          public string Description { get; set; }
          public DateTime DueDate { get; set; }

          public string creatorId { get; set; }
          public int DepartmentId { get; set; }
          public List<DocumentDto> Documents { get; set; } 

          public ICollection<ApiUserDto> Users { get; set; } 

    }
}
