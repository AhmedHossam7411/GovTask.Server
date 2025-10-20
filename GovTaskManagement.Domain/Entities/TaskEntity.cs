namespace GovTaskManagement.Domain.Entities
{
    public class TaskEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public User creator { get; set; }
        public string creatorId { get; set; }
        public DepartmentEntity Department { get; set; }
        public int? DepartmentId { get; set; }         
        public List<DocumentEntity> Documents { get; set; } = new List<DocumentEntity>();

        public ICollection<User> Users { get; set; }  


    }
}
