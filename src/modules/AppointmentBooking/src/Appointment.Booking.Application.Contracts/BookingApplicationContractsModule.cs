using Volo.Abp.Modularity;

namespace Appointment.Booking;

[DependsOn(
    typeof(BookingDomainSharedModule)
)]
public class BookingApplicationContractsModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        BookingDtoExtensions.Configure();
    }
}
