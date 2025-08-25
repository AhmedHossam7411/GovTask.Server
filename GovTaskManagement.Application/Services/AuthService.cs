using GovTaskManagement.Application.Dtos;
using GovTaskManagement.Application.Interfaces.Repositories;
using GovTaskManagement.Application.Interfaces.ServiceInterfaces;
using GovTaskManagement.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GovTaskManagement.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;
        public AuthService(IConfiguration config , IUnitOfWork unitOfWork , IUserRepository _userRepository)
        {
            _unitOfWork = unitOfWork;
            _configuration = config;
        }
        public async Task<string?> LoginAsync(LoginRequestDto loginDto) 
        {
            try
            {
                var userExists = await _unitOfWork.UserRepository.SearchByEmailAsync(loginDto.email);
                if (userExists is null)
                    return null;

                var validPassword = await _unitOfWork.UserRepository.CheckPasswordAsync(userExists, loginDto.password);
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
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<string?> RegisterAsync(RegisterRequestDto registerDto)
        {
            try
            {
                if (registerDto.Role == "MinistryAdmin")
                {
                    var existingMinistryAdmin = await _unitOfWork.UserRepository.FindByRoleAsync("MinistryAdmin");
                    if (existingMinistryAdmin == true)
                        throw new Exception("MinistryAdmin already exists.");
                }
                if (registerDto.Role == "DepartmentAdmin" && registerDto.DepartmentId != null)
                {
                    var existingDeptAdmin = await _unitOfWork.UserRepository.FindByRoleAndDepartmentAsync("DepartmentAdmin",registerDto.DepartmentId.Value);
                    if (existingDeptAdmin == true)
                        throw new Exception("A DepartmentAdmin already exists for this department.");
                }
                if (registerDto.Role == "DepartmentUser" && registerDto.DepartmentId != null)
                {
                    var existingUser = await _unitOfWork.UserRepository.SearchByEmailAsync(registerDto.email);
                    if (existingUser != null)
                        throw new Exception("Department User already Exists");
                }
                var user = new ApiUser
                {
                    UserName = registerDto.userName,
                    Email = registerDto.email,
                    DepartmentId = registerDto.DepartmentId,
                    Role = registerDto.Role
                };
                var result = await _unitOfWork.UserRepository.CreateUserAsync(user, registerDto.password);

                if (!result.Succeeded)
                {

                    foreach (var error in result.Errors)
                    {
                        Console.WriteLine(error.Description);
                    }
                }
                var token = JwtTokenGenerator.GenerateToken(user,
                    _configuration["Jwt:Key"],
                    _configuration["Jwt:Issuer"],
                    _configuration["Jwt:Audience"]
                    );
                await _unitOfWork.SaveChangesAsync();
                return token;

            }
            catch (Exception)
            {

                throw;
            }
        }
         

    }
}
