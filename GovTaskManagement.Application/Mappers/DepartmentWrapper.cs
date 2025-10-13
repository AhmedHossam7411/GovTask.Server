using GovTaskManagement.Application.Dtos;
using GovTaskManagement.Domain.Entities;

namespace GovTaskManagement.Application.Mappers
{
    public static class DepartmentWrapper
    {
        public static DepartmentDto ToDto(this DepartmentEntity department)
        {
            return new DepartmentDto
            {
                Id = department.Id,
                Name = department.Name,
            };
        }
        public static DepartmentEntity ToEntity(this DepartmentDto entity)
        {
            return new DepartmentEntity
            {
                Name = entity.Name,
            };
        }
        public static IEnumerable<DepartmentDto> ToDto(this IEnumerable<DepartmentEntity> entities)
        {
            return entities.Select(e => e.ToDto());
        }
    }
}
