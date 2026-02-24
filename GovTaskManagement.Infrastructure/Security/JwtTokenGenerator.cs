using GovTaskManagement.Application.Interfaces.Security;
using GovTaskManagement.Domain.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace GovTaskManagement.Infrastructure.Security
{
    public class JwtTokenGenerator : IJwtTokenGenerator
    {
            private readonly IConfiguration _configuration;

            public JwtTokenGenerator(IConfiguration configuration)
            {
                _configuration = configuration;
            }

            public string GenerateToken(ApiUser user)
            {
                var secretKey = _configuration["Jwt:Key"];
                var issuer = _configuration["Jwt:Issuer"];
                var audience = _configuration["Jwt:Audience"];
                var expiryMinutes = int.Parse(_configuration["Jwt:ExpiryMinutes"] ?? "1");

                var securityKey = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(secretKey));

                var credentials = new SigningCredentials(
                    securityKey,
                    SecurityAlgorithms.HmacSha256);

                var claims = new[]
                {
            new Claim(ClaimTypes.NameIdentifier, user.Id),
            new Claim(ClaimTypes.Name, user.UserName!)
            };

                var token = new JwtSecurityToken(
                    issuer,
                    audience,
                    claims,
                    expires: DateTime.UtcNow.AddMinutes(expiryMinutes),
                    signingCredentials: credentials);

                return new JwtSecurityTokenHandler().WriteToken(token);
            }
        }
    }



