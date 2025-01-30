using Volo.Abp.Modularity;

namespace Appointment.Booking;

[DependsOn(
    typeof(BookingDomainModule),
    typeof(BookingTestBaseModule)
)]
public class BookingDomainTestModule : AbpModule
{

}
