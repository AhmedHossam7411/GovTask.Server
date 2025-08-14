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
        public int userId { get; set; }  // primary key , auto generated upon new user registeration
        public string userName { get; set; } 
        [Required]
        public string userEmail { get; set; }

        public DocumentEntity DocumentEntity { get; set; }
        public List<DocumentEntity> Documents { get; set; }

        public ICollection<TaskEntity> Tasks { get; set; } = new List<TaskEntity>();

    }
}
