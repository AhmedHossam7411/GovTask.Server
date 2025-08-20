using GovTaskManagement.Application.Dtos;
using Microsoft.AspNetCore.Identity;

namespace GovTaskManagement.Application.Interfaces.ServiceInterfaces
{
    public interface IAuthService
    {
        // Define methods for authentication and authorization
        public Task<bool> LoginAsync(LoginRequestDto loginDto);
        public Task<IdentityResult> RegisterAsync(RegisterRequestDto registerDto);
        //Task<bool> LogoutAsync(string token);
        
    }
}