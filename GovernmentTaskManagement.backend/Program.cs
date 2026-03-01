using GovTaskManagement.Domain.Entities;
using GovTaskManagement.Infrastructure;
using GovTaskManagement.Infrastructure.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
var key = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]));

builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddExceptionHandler<ExceptionHandlingMiddleware>();
builder.Services.AddProblemDetails();

builder.Services.AddIdentityCore<ApiUser>()
.AddEntityFrameworkStores<ToolDbContext>()
.AddDefaultTokenProviders();


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Enter: Bearer {your token}"
    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
{
new OpenApiSecurityScheme
{
    Reference = new OpenApiReference
{
    Type = ReferenceType.SecurityScheme,
    Id = "Bearer"
    }
},
    new string[] {}
        }
    });
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngular",
        policy => policy.WithOrigins("http://localhost:4200")
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowCredentials());
});

var app = builder.Build();
app.UseHttpsRedirection();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAngular");
app.UseExceptionHandler();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();
