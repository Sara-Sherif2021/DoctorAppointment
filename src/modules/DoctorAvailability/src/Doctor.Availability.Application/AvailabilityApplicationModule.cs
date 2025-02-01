using Doctor.Availability.Share;
using Volo.Abp.Application;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;

namespace Doctor.Availability;

[DependsOn(
    typeof(AvailabilityDomainModule),
    typeof(AbpDddApplicationModule),
    typeof(AvailabilityShareModule),
    typeof(AbpAutoMapperModule)
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
