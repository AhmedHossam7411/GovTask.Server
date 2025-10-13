using GovTaskManagement.Domain.Entities;

namespace GovTaskManagement.Application.Dtos
{
    public class ApiUserDto
    {
        public string Id { get; set; }
        public string Role { get; set; }
        public int DepartmentId { get; set; }
        public ICollection<TaskDto> Tasks { get; set; } 
        public ICollection<TaskDto> CreatedTasks { get; set; }


    }
}
