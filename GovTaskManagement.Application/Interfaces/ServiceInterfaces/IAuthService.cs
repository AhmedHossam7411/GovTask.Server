using GovTaskManagement.Application.Dtos;

namespace GovTaskManagement.Application.Services
{
    internal interface IAuthService
    {
        // Define methods for authentication and authorization
        public Task<bool> LoginAsync(LoginRequestDto loginDto);
        public Task<bool> RegisterAsync(RegisterRequestDto registerDto);
        //Task<bool> LogoutAsync(string token);
        
    }
}