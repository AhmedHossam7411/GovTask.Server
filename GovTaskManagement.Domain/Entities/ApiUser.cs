using Microsoft.AspNetCore.Identity;

namespace GovTaskManagement.Domain.Entities
{
    public class ApiUser : IdentityUser
    {
        public int Id { get; set; }
        public string Role { get; set; } = "User";

        public ICollection<TaskEntity> Tasks { get; set; } = new List<TaskEntity>();

        public int? DepartmentId { get; set; }
        public DepartmentEntity Department { get; set; }

    }
}
