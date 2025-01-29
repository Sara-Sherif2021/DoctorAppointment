using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;

namespace Doctor.Availability;

[DependsOn(
    typeof(AvailabilityDomainModule)
    )]
public class AvailabilityApplicationModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpAutoMapperOptions>(options =>
        {
            options.AddMaps<AvailabilityApplicationModule>();
        });
    }
}
