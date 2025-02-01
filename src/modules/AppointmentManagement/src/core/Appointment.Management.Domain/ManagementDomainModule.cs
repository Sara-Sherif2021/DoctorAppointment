using Volo.Abp.Modularity;

namespace Appointment.Management;

[DependsOn(
    typeof(ManagementDomainSharedModule)
    )]
public class ManagementDomainModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
      
        

#if DEBUG
#endif
    }
}
