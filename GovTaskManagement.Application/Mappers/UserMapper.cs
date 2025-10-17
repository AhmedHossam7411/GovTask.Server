using GovTaskManagement.Application.Dtos;
using GovTaskManagement.Domain.Entities;

namespace GovTaskManagement.Application.Mappers
{
    public static class UserMapper
    {
            public static UserDto ToDto(this User user)
            {
                return new UserDto
                {
                    ApiUserId = user.ApiUserId,
                    Role = user.Role,
                    Tasks = user.Tasks?.Select(t => t.ToDto()).ToList(),
                    CreatedTasks = user.CreatedTasks?.Select(t => t.ToDto()).ToList(),
                    DepartmentId = user.DepartmentId,
                
                };
            }
            public static User ToEntity(this UserDto dto)
            {
                return new User
                {
                    ApiUserId = dto.ApiUserId,
                    Role = dto.Role,
                    Tasks = dto.Tasks?.Select(t => t.ToEntity()).ToList(),
                    CreatedTasks = dto.CreatedTasks?.Select(t => t.ToEntity()).ToList(),
                    DepartmentId = dto.DepartmentId,
                };
            }
            public static IEnumerable<UserDto> ToDto(this IEnumerable<User> entities)
            {
                return entities.Select(e => e.ToDto());
            }
        }
    }


