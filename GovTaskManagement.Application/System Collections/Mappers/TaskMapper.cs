using GovTaskManagement.Application.System_Collections.Dtos;
using GovTaskManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GovTaskManagement.Application.System_Collections.Mappers
{
    public static class TaskMapper
    {
        public static TaskDto ToDto(this TaskEntity entity)
        {
            return new TaskDto
            {
                Id = entity.Id,
                Name = entity.Name,
                Description = entity.Description,
                DueDate = entity.DueDate,
                DepartmentId = entity.DepartmentId
            };
        }

        public static IEnumerable<TaskDto> ToDto(this IEnumerable<TaskEntity> entities)
        {
            return entities.Select(e => e.ToDto());
        }
        public static TaskEntity ToEntity(this TaskDto dto)
        {
            return new TaskEntity
            {
                Id = dto.Id,
                Name = dto.Name,
                Description = dto.Description,
                DueDate = dto.DueDate
            };
        }
    }
}
