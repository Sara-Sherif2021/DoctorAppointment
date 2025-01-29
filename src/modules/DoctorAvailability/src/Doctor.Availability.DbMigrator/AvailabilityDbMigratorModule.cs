using Doctor.Availability.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace Doctor.Availability.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(AvailabilityEntityFrameworkCoreModule)
)]
public class AvailabilityDbMigratorModule : AbpModule
{
}
