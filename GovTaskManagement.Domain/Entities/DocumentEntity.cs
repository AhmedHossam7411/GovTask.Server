namespace GovTaskManagement.Domain.Entities
{
    public class DocumentEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime UploadDate { get; set; }
        public int TaskId { get; set; }
        public TaskEntity Task { get; set; }
    }
}
