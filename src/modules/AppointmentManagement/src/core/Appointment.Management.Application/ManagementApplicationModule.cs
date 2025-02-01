using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;

namespace Appointment.Management;

[DependsOn(
    typeof(ManagementDomainModule),
    typeof(ManagementApplicationContractsModule),
    typeof(AbpAutoMapperModule)
    )]
public class ManagementApplicationModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpAutoMapperOptions>(options =>
        {
            options.AddMaps<ManagementApplicationModule>();
        });
    }
}
