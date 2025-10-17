using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GovTaskManagement.Application.Dtos
{
    public class UserInTaskDto
    {
        public string ApiUserId { get; set; }
        public string Role { get; set; }
        public int? DepartmentId { get; set; }
    }
}
