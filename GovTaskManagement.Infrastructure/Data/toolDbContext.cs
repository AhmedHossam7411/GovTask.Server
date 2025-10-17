using GovTaskManagement.Domain.Entities;
using Humanizer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.SqlServer;
using System.Collections.Generic;
using System.Reflection.Emit;
namespace GovTaskManagement.Infrastructure.Data
{
    public class ToolDbContext(DbContextOptions<ToolDbContext> options) : IdentityDbContext<ApiUser>(options) 
    {
        public DbSet<DocumentEntity> Documents { get; set; }
        public DbSet<DepartmentEntity> Departments { get; set; }
        public DbSet<TaskEntity> Tasks { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ToolDbContext).Assembly);


            modelBuilder.Entity<User>()
             .HasMany(u => u.Tasks)
              .WithMany(t => t.Users)
               .UsingEntity(j => j.ToTable("Users-Tasks"));
         
           modelBuilder.Entity<DocumentEntity>()
           .HasOne(d => d.Task)             
           .WithMany(t => t.Documents)      
           .HasForeignKey(d => d.TaskId)    
           .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<User>()
                .HasOne(u => u.Department)
                .WithMany(d => d.Users)
                .HasForeignKey(u => u.DepartmentId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ApiUser>()
                .HasIndex(u => u.UserName)
               .IsUnique();
             modelBuilder.Entity<ApiUser>()
                .Property(u => u.UserName)
                .IsRequired();
            modelBuilder.Entity<User>()
                .Property(u => u.Role)
                .HasDefaultValue("User");

            modelBuilder.Entity<User>()
              .HasMany(u => u.CreatedTasks)
              .WithOne(u => u.creator)
              .HasForeignKey(u => u.creatorId)
              .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<DepartmentEntity>()
            .HasMany(u => u.Tasks)
            .WithOne(t => t.Department)
            .HasForeignKey(t => t.DepartmentId)
            .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<User>()
                .HasKey(u => u.ApiUserId);
            modelBuilder.Entity<User>()
                .HasOne(u => u.ApiUser)
                .WithOne(a => a.User)
                .HasForeignKey<User>(u => u.ApiUserId);
        }
      

    }
}
