using Microsoft.AspNetCore.Identity;

namespace GovTaskManagement.Domain.Entities
{
    public class ApiUser : IdentityUser
    {
        public string Role { get; set; } = "User";

        public ICollection<TaskEntity> Tasks { get; set; } = new List<TaskEntity>();
        public ICollection<TaskEntity> CreatedTasks { get; set; }

        public int? DepartmentId { get; set; }
        public DepartmentEntity Department { get; set; }

    }
}
