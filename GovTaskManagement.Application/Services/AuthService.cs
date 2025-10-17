using GovTaskManagement.Application.Dtos;
using GovTaskManagement.Application.Interfaces.Repositories;
using GovTaskManagement.Application.Interfaces.ServiceInterfaces;
using GovTaskManagement.Domain.Entities;
using Microsoft.Extensions.Configuration;

namespace GovTaskManagement.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;
        public AuthService(IConfiguration config, IUnitOfWork unitOfWork, IApiUserRepository _apiUserRepository)
        {
            _unitOfWork = unitOfWork;
            _configuration = config;
        }
        public async Task<string?> LoginAsync(LoginRequestDto loginDto)
        {
            var userExists = await _unitOfWork.ApiUserRepository.SearchByEmailAsync(loginDto.email);
            if (userExists is null)
                return null;

            var validPassword = await _unitOfWork.ApiUserRepository.CheckPasswordAsync(userExists, loginDto.password);
            if (validPassword is false)
                return null;

            var token = JwtTokenGenerator.GenerateToken(userExists,
                _configuration["Jwt:Key"],
                _configuration["Jwt:Issuer"],
                _configuration["Jwt:Audience"]
                );
            await _unitOfWork.SaveChangesAsync();
            return token;

        }
        public async Task<string?> RegisterAsync(RegisterRequestDto registerDto)
        {
            var user = new ApiUser
            {
                UserName = registerDto.UserName,
                Email = registerDto.email,
            };
            var result = await _unitOfWork.ApiUserRepository.CreateUserAsync(user, registerDto.password);

            if (!result.Succeeded)
            {
                throw new InvalidOperationException(string.Join(',',result.Errors.Select(e=>e.Description)));
            }
            var appUser = new User
            {
                ApiUserId = user.Id,
                Role = "User",
                DepartmentId = null,
            };
            await _unitOfWork.UserRepository.CreateAsync(appUser);
            await _unitOfWork.SaveChangesAsync();

            var token = JwtTokenGenerator.GenerateToken(user,
                _configuration["Jwt:Key"],
                _configuration["Jwt:Issuer"],
                _configuration["Jwt:Audience"]
                );
            await _unitOfWork.SaveChangesAsync();
            return token;

        }
    }
}

        
         

   
