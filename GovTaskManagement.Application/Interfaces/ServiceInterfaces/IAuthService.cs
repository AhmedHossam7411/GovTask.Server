using GovTaskManagement.Application.Dtos;
using Microsoft.AspNetCore.Identity;

namespace GovTaskManagement.Application.Interfaces.ServiceInterfaces
{
    public interface IAuthService
    {
        
        Task<AuthResponseDto?> LoginAsync(LoginRequestDto loginDto);
        Task<string?> RegisterAsync(RegisterRequestDto registerDto);
        Task LogoutAsync(string refreshToken);


    }
}