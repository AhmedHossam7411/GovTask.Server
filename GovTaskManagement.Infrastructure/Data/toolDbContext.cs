using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.SqlServer;
using System.Collections.Generic;
using System.Reflection.Emit;
namespace GovernmentTaskManagement.backend.Data
{
    public class toolDbContext(DbContextOptions<toolDbContext> options) : IdentityDbContext<IdentityUser>(options) // identity enables us to use ASPNET USER AND ROLES tables for auth and authorization
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(toolDbContext).Assembly);
        }
    }
}
