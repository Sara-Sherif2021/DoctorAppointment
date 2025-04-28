using Appointment.Management.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace Appointment.Management.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(ManagementEntityFrameworkCoreModule),
    typeof(ManagementApplicationContractsModule)
)]
public class ManagementDbMigratorModule : AbpModule
{
}
