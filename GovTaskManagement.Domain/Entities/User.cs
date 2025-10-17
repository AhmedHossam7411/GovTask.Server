namespace GovTaskManagement.Domain.Entities
{
    public class User
    
    {
        public ApiUser ApiUser { get; set; }
        public string ApiUserId { get; set; }
        public string Role { get; set; }
        public ICollection<TaskEntity> Tasks { get; set; }
        public ICollection<TaskEntity> CreatedTasks { get; set; }
        public int? DepartmentId { get; set; }
        public DepartmentEntity Department { get; set; }
    }
}
