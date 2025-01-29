using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Doctor.Availability.EntityFrameworkCore;

/* This class is needed for EF Core console commands
 * (like Add-Migration and Update-Database commands) */
public class AvailabilityDbContextFactory : IDesignTimeDbContextFactory<AvailabilityDbContext>
{
    public AvailabilityDbContext CreateDbContext(string[] args)
    {
        var configuration = BuildConfiguration();
        
        AvailabilityEfCoreEntityExtensionMappings.Configure();

        var builder = new DbContextOptionsBuilder<AvailabilityDbContext>()
            .UseSqlServer(configuration.GetConnectionString("Default"));
        
        return new AvailabilityDbContext(builder.Options);
    }

    private static IConfigurationRoot BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../Doctor.Availability.DbMigrator/"))
            .AddJsonFile("appsettings.json", optional: false);

        return builder.Build();
    }
}
