using GovTaskManagement.Application.Interfaces.Repositories;
using GovTaskManagement.Application.Interfaces.ServiceInterfaces;
using GovTaskManagement.Application.Services;
using GovTaskManagement.Domain.Entities;
using GovTaskManagement.Infrastructure.Data;
using GovTaskManagement.Infrastructure.Repositories;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
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
            Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            Services.AddScoped<IUserRepository, UserRepository>();
            Services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            Services.AddScoped<IDocumentRepository, DocumentRepository>();
            Services.AddScoped<ITaskRepository, TaskRepository>();

            Services.AddScoped<IUnitOfWork, UnitOfWork>();

            Services.AddScoped<IAuthService, AuthService>();
            Services.AddScoped<ITaskService, TaskService>();
            Services.AddScoped<IDepartmentService, DepartmentService>();
            Services.AddScoped<IDocumentService, DocumentService>();


            Services.AddDbContext<ToolDbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            var jwtKey = Configuration["Jwt:Key"];
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
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtIssuer,
                    ValidAudience = jwtAud,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey))
                };
            });

            return Services;
        }
    }
}
