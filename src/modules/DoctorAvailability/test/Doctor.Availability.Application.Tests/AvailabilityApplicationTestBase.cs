using Volo.Abp.Modularity;

namespace Doctor.Availability;

public abstract class AvailabilityApplicationTestBase<TStartupModule> : AvailabilityTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
