namespace GovTaskManagement.Domain.Entities
{
    public class DepartmentEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<User>? Users { get; set; }  
        public List<TaskEntity>? Tasks { get; set; }

    }
}
