using Shouldly;
using System.Threading.Tasks;
using Volo.Abp.Modularity;
using Xunit;

namespace Appointment.Booking.Samples;

/* This is just an example test class.
 * Normally, you don't test code of the modules you are using
 * (like IIdentityUserAppService here).
 * Only test your own application services.
 */
public abstract class SampleAppServiceTests<TStartupModule> : BookingApplicationTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

    protected SampleAppServiceTests()
    {
    }
}
