using Volo.Abp.Modularity;

namespace Appointment.Management;

[DependsOn(
    typeof(ManagementDomainSharedModule)
)]
public class ManagementApplicationContractsModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        ManagementDtoExtensions.Configure();
    }
}
