using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.SqlServer;
using Volo.Abp.Modularity;
using Volo.Abp.Studio;
using Microsoft.Extensions.DependencyInjection;

namespace Appointment.Booking.EntityFrameworkCore;

[DependsOn(
    typeof(BookingDomainModule),
    typeof(AbpEntityFrameworkCoreSqlServerModule)
    )]
public class BookingEntityFrameworkCoreModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {

        BookingEfCoreEntityExtensionMappings.Configure();
    }

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddAbpDbContext<BookingDbContext>(options =>
        {
                /* Remove "includeAllEntities: true" to create
                 * default repositories only for aggregate roots */
            options.AddDefaultRepositories(includeAllEntities: true);
        });

        if (AbpStudioAnalyzeHelper.IsInAnalyzeMode)
        {
            return;
        }

        Configure<AbpDbContextOptions>(options =>
        {
                /* The main point to change your DBMS.
                 * See also BookingDbContextFactory for EF Core tooling. */
            options.UseSqlServer();
        });
        
    }
}
