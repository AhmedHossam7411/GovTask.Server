using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GovTaskManagement.Domain.Entities
{
    public class ApiUser : IdentityUser
    {
        public int Id { get; set; }  // primary key , auto generated upon new user registeration
        //public string userName { get; set; } 
        
        //public string userEmail { get; set; }

        

        public ICollection<TaskEntity> Tasks { get; set; } = new List<TaskEntity>();

        public int? DepartmentId { get; set; }
        public DepartmentEntity Department { get; set; }

    }
}
