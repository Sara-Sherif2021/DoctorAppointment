using Volo.Abp.Modularity;

namespace Appointment.Booking;

[DependsOn(
    typeof(BookingApplicationModule),
    typeof(BookingDomainTestModule)
)]
public class BookingApplicationTestModule : AbpModule
{

}
