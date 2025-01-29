using Shouldly;
using System.Threading.Tasks;
using Volo.Abp.Modularity;
using Xunit;

namespace Doctor.Availability.Samples;

/* This is just an example test class.
 * Normally, you don't test code of the modules you are using
 * (like IdentityUserManager here).
 * Only test your own domain services.
 */
public abstract class SampleDomainTests<TStartupModule> : AvailabilityDomainTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{
    protected SampleDomainTests()
    {
    }

}
