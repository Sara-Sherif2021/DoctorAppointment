using Volo.Abp.Account;
using Volo.Abp.Modularity;

namespace Appointment.Booking;

[DependsOn(
    typeof(BookingDomainSharedModule),
    typeof(AbpAccountApplicationContractsModule)
)]
public class BookingApplicationContractsModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        BookingDtoExtensions.Configure();
    }
}
