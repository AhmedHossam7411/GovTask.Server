using GovTaskManagement.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.SqlServer;
using System.Collections.Generic;
using System.Reflection.Emit;
namespace GovTaskManagement.Infrastructure.Data
{
    public class toolDbContext(DbContextOptions<toolDbContext> options) : IdentityDbContext<IdentityUser>(options) // identity enables us to use ASPNET USER AND ROLES tables for auth and authorization
    {
        public DbSet<ApiUser> Users { get; set; }
        public DbSet<DocumentEntity> Documents { get; set; }
        public DbSet<DepartmentEntity> Departments { get; set; }
        public DbSet<TaskEntity> Tasks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(toolDbContext).Assembly);

            modelBuilder.Entity<ApiUser>()
             .HasMany(u => u.Tasks)
              .WithMany(t => t.Users)
               .UsingEntity(j => j.ToTable("Users-Tasks"));
        }
    }
}
