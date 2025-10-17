
using GovTaskManagement.Domain.Entities;

namespace GovTaskManagement.Application.Dtos
{
    public class UserDto
    {
        public string ApiUserId { get; set; }
        public string Role { get; set; }
        public ICollection<TaskDto> Tasks { get; set; }
        public ICollection<TaskDto> CreatedTasks { get; set; }
        public int? DepartmentId { get; set; }
    }
}
