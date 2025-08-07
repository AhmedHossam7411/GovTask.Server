using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GovTaskManagement.Domain.Entities
{
    internal class ApiUser : IdentityUser
    {
        public int userId { get; set; }
        public string userName { get; set; } 
        [Required]
        public string userEmail { get; set; }

        Task Task { get; set; }   // Navigation property to Task assigned to user
        List<Task> Tasks { get; set; }  

    }
}
