using Volo.Abp.Modularity;

namespace Appointment.Management;

[DependsOn(
    typeof(ManagementDomainModule),
    typeof(ManagementTestBaseModule)
)]
public class ManagementDomainTestModule : AbpModule
{

}
