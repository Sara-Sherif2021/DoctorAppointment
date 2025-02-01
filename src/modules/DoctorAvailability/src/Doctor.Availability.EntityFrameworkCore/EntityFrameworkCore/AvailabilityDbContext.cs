using Microsoft.EntityFrameworkCore;
using Volo.Abp.AuditLogging.EntityFrameworkCore;
using Doctor.Availability.Entities;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;
using System.Reflection.Emit;
using System.Reflection;

namespace Doctor.Availability.EntityFrameworkCore;

[ConnectionStringName("DoctorAvailability")]
public class AvailabilityDbContext :
    AbpDbContext<AvailabilityDbContext>
{
    /* Add DbSet properties for your Aggregate Roots / Entities here. */


    #region Entities from the modules
    public DbSet<Entities.Doctor> Doctors { get; set; }
    public DbSet<Slot> Slots { get; set; }


    #endregion

    public AvailabilityDbContext(DbContextOptions<AvailabilityDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        /* Include modules to your migration db context */

        builder.ConfigureAuditLogging();

        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
