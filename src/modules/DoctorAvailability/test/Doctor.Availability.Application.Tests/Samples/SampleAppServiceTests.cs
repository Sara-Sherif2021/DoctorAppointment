using Volo.Abp.Modularity;

namespace Doctor.Availability.Samples;

/* This is just an example test class.
 * Normally, you don't test code of the modules you are using
 * (like IIdentityUserAppService here).
 * Only test your own application services.
 */
public abstract class SampleAppServiceTests<TStartupModule> : AvailabilityApplicationTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{
}
