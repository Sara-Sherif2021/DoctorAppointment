using Volo.Abp.Modularity;

namespace Doctor.Availability;

[DependsOn(
    typeof(AvailabilityApplicationModule),
    typeof(AvailabilityDomainTestModule)
)]
public class AvailabilityApplicationTestModule : AbpModule
{

}
