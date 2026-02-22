using GovTaskManagement.Application.Dtos;
using GovTaskManagement.Application.Interfaces.Repositories;
using GovTaskManagement.Application.Interfaces.ServiceInterfaces;
using GovTaskManagement.Domain.Entities;
using Microsoft.Extensions.Configuration;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
        public async Task<AuthResponseDto?> LoginAsync(LoginRequestDto loginDto)
        {
            var user = await _unitOfWork.ApiUserRepository
                .SearchByEmailAsync(loginDto.email);

            if (user is null)
                return null;

            var validPassword = await _unitOfWork
                .ApiUserRepository
                .CheckPasswordAsync(user, loginDto.password);

            if (!validPassword)
                return null;

            var accessToken = JwtTokenGenerator.GenerateToken(
                user,
                _configuration["Jwt:Key"],
                _configuration["Jwt:Issuer"],
                _configuration["Jwt:Audience"]
            );
            var refreshToken = Guid.NewGuid().ToString(); 
            var refreshTokenEntity = new RefreshToken
            {
                Token = refreshToken,
                UserId = user.Id,
                ExpiresAt = DateTime.UtcNow.AddDays(7),
                IsRevoked = false
            };
            await _unitOfWork.RefreshTokenRepository.AddAsync(refreshTokenEntity);
            await _unitOfWork.SaveChangesAsync();
 
            return new AuthResponseDto
            {
                AccessToken = accessToken,
                RefreshToken = refreshToken
            };
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
        public async Task LogoutAsync(string refreshToken)
        {
            if (string.IsNullOrEmpty(refreshToken))
                return;

            var tokenEntity = await _unitOfWork
                .RefreshTokenRepository
                .GetByTokenAsync(refreshToken);

            if (tokenEntity == null)
                return;

            if (tokenEntity.IsRevoked)
                return;

            if (tokenEntity.ExpiresAt < DateTime.UtcNow)
                return;

            tokenEntity.IsRevoked = true;

            await _unitOfWork.SaveChangesAsync();
        }
    }
}

        
         

   
