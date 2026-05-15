using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace GovTaskManagement.Infrastructure.Data
{
    public class ToolDbContextFactory : IDesignTimeDbContextFactory<ToolDbContext>
    {
        public ToolDbContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "..", "GovernmentTaskManagement.backend"))
                .AddJsonFile("appsettings.json", optional: true)
                .AddJsonFile("appsettings.Development.json", optional: true)
                .AddEnvironmentVariables()
                .Build();

            var connectionString = configuration.GetConnectionString("DefaultConnection")
                ?? "Server=.\\SQLEXPRESS;Database=GovernmentTaskManagementDB;Trusted_Connection=True;TrustServerCertificate=True;";

            var options = new DbContextOptionsBuilder<ToolDbContext>()
                .UseSqlServer(connectionString)
                .Options;

            return new ToolDbContext(options);
        }
    }
}
