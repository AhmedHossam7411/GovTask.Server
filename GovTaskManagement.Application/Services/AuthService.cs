using GovTaskManagement.Application.Dtos;
using GovTaskManagement.Application.Interfaces.Repositories;
using GovTaskManagement.Application.Interfaces.Security;
using GovTaskManagement.Application.Interfaces.ServiceInterfaces;
using GovTaskManagement.Domain.Entities;
using Microsoft.Extensions.Configuration;

namespace GovTaskManagement.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;
        private readonly ITokenHasher _tokenHasher;
        private readonly IJwtTokenGenerator _jwtGenerator;
        public AuthService(IConfiguration config, IUnitOfWork unitOfWork,
            IApiUserRepository _apiUserRepository,
            ITokenHasher tokenHasher,
            IJwtTokenGenerator jwtGenerator)
        {
            _unitOfWork = unitOfWork;
            _configuration = config;
            _tokenHasher = tokenHasher;
            _jwtGenerator = jwtGenerator;
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

            var accessToken = _jwtGenerator.GenerateToken(user);
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

            var token = _jwtGenerator.GenerateToken(user);
          
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
        public async Task<AuthResponseDto?> RefreshTokenAsync(string refreshToken)
        {
            if (string.IsNullOrEmpty(refreshToken))
                return null;

            var tokenEntity = await _unitOfWork
                .RefreshTokenRepository
                .GetByTokenAsync(refreshToken);

            if (tokenEntity == null
                || tokenEntity.IsRevoked
                || tokenEntity.ExpiresAt < DateTime.UtcNow)
                return null;

            var user = await _unitOfWork
                .ApiUserRepository
                .FindByIdAsync(tokenEntity.UserId);

            if (user == null)
                return null;

            var newAccessToken = _jwtGenerator.GenerateToken(user);

            tokenEntity.IsRevoked = true;

            var newRefreshToken = Guid.NewGuid().ToString();
            var hashedToken = _tokenHasher.Hash(newRefreshToken);

            var newTokenEntity = new RefreshToken
            {
                Token = hashedToken,
                UserId = user.Id,
                ExpiresAt = DateTime.UtcNow.AddDays(7),
                IsRevoked = false
            };

            await _unitOfWork.RefreshTokenRepository.AddAsync(newTokenEntity);
            await _unitOfWork.SaveChangesAsync();

            return new AuthResponseDto
            {
                AccessToken = newAccessToken,
                RefreshToken = newRefreshToken // no rotation yet
            };
        }
    }
}

        
         

   
