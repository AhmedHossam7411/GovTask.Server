using GovTaskManagement.Application.Dtos;
using GovTaskManagement.Domain.Entities;

namespace GovTaskManagement.Application.Mappers
{
    public static class ApiUserMapper
    {
        public static ApiUserDto ToDto(this ApiUser entity)
        {
            return new ApiUserDto
            {
                Role = entity.Role,
                Tasks = entity.Tasks.Select(u => u.ToDto()).ToList(),
                CreatedTasks = entity.CreatedTasks.Select(u => u.ToDto()).ToList(),
            };
        }

        public static ApiUser ToEntity(this ApiUserDto dto)
        {
            return new ApiUser
            {
                Role = dto.Role,
                Tasks = dto.Tasks.Select(u => u.ToEntity()).ToList(),
                CreatedTasks = dto.CreatedTasks.Select(u => u.ToEntity()).ToList(),

            };
        }

        public static IEnumerable<ApiUserDto> ToDto(this IEnumerable<ApiUser> entities)
        {
            return entities.Select(u => u.ToDto());
        }
    }
}
