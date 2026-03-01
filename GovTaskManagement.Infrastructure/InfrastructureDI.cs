using GovTaskManagement.Application.Interfaces.Repositories;
using GovTaskManagement.Application.Interfaces.Security;
using GovTaskManagement.Application.Interfaces.ServiceInterfaces;
using GovTaskManagement.Application.Services;
using GovTaskManagement.Infrastructure.Data;
using GovTaskManagement.Infrastructure.Repositories;
using GovTaskManagement.Infrastructure.Security;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace GovTaskManagement.Infrastructure
{
    public static class InfrastructureDI
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection Services, IConfiguration Configuration)
        {
            Services.AddScoped(typeof(IGenericRepository<,>),typeof(GenericRepository<,>));
            Services.AddScoped<IUserRepository, UserRepository>();
            Services.AddScoped<IApiUserRepository, ApiUserRepository>();
            Services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            Services.AddScoped<IDocumentRepository, DocumentRepository>();
            Services.AddScoped<ITaskRepository, TaskRepository>();
            Services.AddScoped<IRefreshTokenRepository, RefreshTokenRepository>();

            Services.AddScoped<IUnitOfWork, UnitOfWork>();

            Services.AddScoped<IAuthService, AuthService>();
            Services.AddScoped<ITaskService, TaskService>();
            Services.AddScoped<IDepartmentService, DepartmentService>();
            Services.AddScoped<IDocumentService, DocumentService>();

            Services.AddScoped<ITokenHasher, Sha256TokenHasher>();
            Services.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>();

            Services.AddDbContext<ToolDbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]));
            var jwtIssuer = Configuration["Jwt:Issuer"];
            var jwtAud = Configuration["Jwt:Audience"];

            Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidIssuer = Configuration["Jwt:Issuer"],

                ValidateAudience = true,
                ValidAudience = Configuration["Jwt:Audience"],

                ValidateIssuerSigningKey = true,
                IssuerSigningKey = key,

                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero
            };
        });

            return Services;
        }
    }
}
