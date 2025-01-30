using Volo.Abp.Modularity;

namespace Appointment.Booking;

/* Inherit from this class for your domain layer tests. */
public abstract class BookingDomainTestBase<TStartupModule> : BookingTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
