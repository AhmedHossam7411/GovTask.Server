using GovTaskManagement.Application.Interfaces.Repositories;
using GovTaskManagement.Application.Interfaces.ServiceInterfaces;
using GovTaskManagement.Application.Services;
using GovTaskManagement.Domain.Entities;
using GovTaskManagement.Infrastructure;
using GovTaskManagement.Infrastructure.Data;
using GovTaskManagement.Infrastructure.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;


      var builder = WebApplication.CreateBuilder(args);

      builder.Services.AddInfrastructure(builder.Configuration);
      builder.Services.AddIdentity<ApiUser, IdentityRole>()
      .AddEntityFrameworkStores<ToolDbContext>()
      .AddDefaultTokenProviders();

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthentication(); 
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        
    

