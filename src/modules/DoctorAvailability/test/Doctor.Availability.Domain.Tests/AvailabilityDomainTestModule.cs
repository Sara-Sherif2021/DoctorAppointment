using Volo.Abp.Modularity;

namespace Doctor.Availability;

[DependsOn(
    typeof(AvailabilityDomainModule),
    typeof(AvailabilityTestBaseModule)
)]
public class AvailabilityDomainTestModule : AbpModule
{

}
