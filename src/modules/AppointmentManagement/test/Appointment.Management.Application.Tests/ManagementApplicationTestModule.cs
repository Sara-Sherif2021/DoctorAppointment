using Volo.Abp.Modularity;

namespace Appointment.Management;

[DependsOn(
    typeof(ManagementApplicationModule),
    typeof(ManagementDomainTestModule)
)]
public class ManagementApplicationTestModule : AbpModule
{

}
