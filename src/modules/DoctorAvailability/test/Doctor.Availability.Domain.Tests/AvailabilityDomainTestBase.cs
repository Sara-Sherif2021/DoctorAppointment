using Volo.Abp.Modularity;

namespace Doctor.Availability;

/* Inherit from this class for your domain layer tests. */
public abstract class AvailabilityDomainTestBase<TStartupModule> : AvailabilityTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
