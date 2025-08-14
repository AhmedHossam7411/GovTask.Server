using GovTaskManagement.Application.Dtos;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GovTaskManagement.Domain.Entities;
using GovTaskManagement.Application.Interfaces.Repositories;

namespace GovTaskManagement.Application.Services
{
    public class AuthService : IAuthService
    {
        private IUnitOfWork _unitOfWork;
        private IUserRepository _userRepository;
        public async Task<bool> LoginAsync(LoginRequestDto loginDto)
        {
            try
            {
                var userExists = await _unitOfWork.UserRepository.SearchByEmailAsync(loginDto.email);
                if (userExists == null)
                    return false; // User does not exist

                var logged = await _unitOfWork.UserRepository.CheckPasswordAsync(userExists, loginDto.password);
                return logged; // Return true if password matches
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<bool> RegisterAsync(RegisterRequestDto registerDto)
        {
            try
            {
                var existingUser = _unitOfWork.UserRepository.SearchByEmailAsync(registerDto.email);
                if (existingUser != null )
                {
                    return false; // User already exists
                }
                var user = new ApiUser
                {
                    UserName = registerDto.userName,
                    Email = registerDto.email,
                    
                };
                var result = await _unitOfWork.UserRepository.CreateUserAsync(user, registerDto.password);
                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }
        

    }
}
