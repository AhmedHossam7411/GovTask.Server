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
        private IUnitOfWork UnitOfWork;
        private IUserRepository UserRepository;

        public AuthService(IUnitOfWork _unitOfWork , IUserRepository _userRepository)
        {
            UnitOfWork = _unitOfWork;
            UserRepository = _userRepository;
        }
        public async Task<bool> LoginAsync(LoginRequestDto loginDto)
        {
            try
            {
                var userExists = await UnitOfWork.UserRepository.SearchByEmailAsync(loginDto.email);
                if (userExists == null)
                    return false; // User does not exist

                var logged = await UnitOfWork.UserRepository.CheckPasswordAsync(userExists, loginDto.password);
                return logged; // Return true if password matches
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<IdentityResult> RegisterAsync(RegisterRequestDto registerDto)
        {
            try
            {
                var existingUser = await UnitOfWork.UserRepository.SearchByEmailAsync(registerDto.email);
                if (existingUser != null )
                {
                    return IdentityResult.Failed(new IdentityError
                    {
                        Description = "User already exists."
                    }); // User already exists
                }
                var user = new ApiUser
                {
                    UserName = registerDto.userName,
                    Email = registerDto.email,
                    
                };
                var result = await UnitOfWork.UserRepository.CreateUserAsync(user, registerDto.password);

                if (!result.Succeeded)
                {
                    
                    foreach (var error in result.Errors)
                    {
                        Console.WriteLine(error.Description);
                    }
                }

                return result;

            }
            catch (Exception)
            {

                throw;
            }
        }
        

    }
}
