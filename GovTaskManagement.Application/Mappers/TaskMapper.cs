using GovTaskManagement.Application.Dtos;
using GovTaskManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GovTaskManagement.Application.Mappers
{
    public static class TaskMapper
    {
        public static TaskDto ToDto(this TaskEntity entity)
        {
            return new TaskDto
            {
                Name = entity.Name,
                Description = entity.Description,
                DueDate = entity.DueDate,
                creatorId = entity.creatorId,
                Users = entity.Users?.Select(u => u.ToDto()).ToList(),
                Documents = entity.Documents?.Select(d => d.ToDto()).ToList(),
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
                Name = dto.Name,
                Description = dto.Description,
                DueDate = dto.DueDate,
                creatorId = dto.creatorId,
                Users = dto.Users?.Select(u => u.ToEntity()).ToList(),
                Documents = dto.Documents?.Select(d => d.ToEntity()).ToList(),
                DepartmentId = dto.DepartmentId
            };
        }
    }
}
