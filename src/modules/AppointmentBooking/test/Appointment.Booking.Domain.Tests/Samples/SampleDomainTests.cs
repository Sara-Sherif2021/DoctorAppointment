﻿using Shouldly;
using System.Threading.Tasks;
using Volo.Abp.Modularity;
using Xunit;

namespace Appointment.Booking.Samples;

/* This is just an example test class.
 * Normally, you don't test code of the modules you are using
 * (like IdentityUserManager here).
 * Only test your own domain services.
 */
public abstract class SampleDomainTests<TStartupModule> : BookingDomainTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

    protected SampleDomainTests()
    {
    }

    [Fact]
    public async Task Should_Set_Email_Of_A_User()
    {

        /* Need to manually start Unit Of Work because
         * FirstOrDefaultAsync should be executed while db connection / context is available.
         */
      
    }
}
