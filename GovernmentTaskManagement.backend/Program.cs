using GovTaskManagement.Application.Interfaces.Repositories;
using GovTaskManagement.Application.Interfaces.ServiceInterfaces;
using GovTaskManagement.Application.Services;
using GovTaskManagement.Domain.Entities;
using GovTaskManagement.Infrastructure;
using GovTaskManagement.Infrastructure.Data;
using GovTaskManagement.Infrastructure.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

    public class Program


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddExceptionHandler<ExceptionHandlingMiddleware>();
builder.Services.AddProblemDetails();

builder.Services.AddIdentity<ApiUser, IdentityRole>()
.AddEntityFrameworkStores<ToolDbContext>()
.AddDefaultTokenProviders();


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
            builder.Services.AddScoped<IDepartmentService, DepartmentService>();
            

            builder.Services.AddIdentity<ApiUser, IdentityRole>()
            .AddEntityFrameworkStores<toolDbContext>()
            .AddDefaultTokenProviders();

            builder.Services.AddDbContext<toolDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

var app = builder.Build();

    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseExceptionHandler();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();
        

            app.Run();
        }
    }
}
