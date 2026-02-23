using GovTaskManagement.Domain.Entities;

namespace GovTaskManagement.Application.Interfaces.Security
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(ApiUser user);
    }
}
