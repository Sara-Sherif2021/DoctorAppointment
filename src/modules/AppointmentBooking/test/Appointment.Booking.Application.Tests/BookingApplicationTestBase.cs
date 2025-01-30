using Volo.Abp.Modularity;

namespace Appointment.Booking;

public abstract class BookingApplicationTestBase<TStartupModule> : BookingTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
