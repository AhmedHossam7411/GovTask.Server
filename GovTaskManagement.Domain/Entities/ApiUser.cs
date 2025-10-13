using Microsoft.AspNetCore.Identity;

namespace GovTaskManagement.Domain.Entities
{
    public class ApiUser : IdentityUser
    {
        public string Role { get; set; } 
        public ICollection<TaskEntity> Tasks { get; set; } 
        public ICollection<TaskEntity> CreatedTasks { get; set; }
        public int DepartmentId { get; set; }
        public DepartmentEntity Department { get; set; }

    }
}
