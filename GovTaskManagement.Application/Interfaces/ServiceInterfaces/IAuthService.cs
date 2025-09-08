using GovTaskManagement.Application.Dtos;
using Microsoft.AspNetCore.Identity;

namespace GovTaskManagement.Application.Interfaces.ServiceInterfaces
{
    public interface IAuthService
    {
        
        Task<string?> LoginAsync(LoginRequestDto loginDto);
        Task<string?> RegisterAsync(RegisterRequestDto registerDto);
        
        
    }
}