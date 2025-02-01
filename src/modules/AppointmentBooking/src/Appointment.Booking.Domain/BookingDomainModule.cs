//using Doctor.Availability.Share;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Volo.Abp.AuditLogging;
using Volo.Abp.Caching;
using Volo.Abp.Modularity;

namespace Appointment.Booking;

[DependsOn(
    typeof(BookingDomainSharedModule)
    )]
public class BookingDomainModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {


#if DEBUG
#endif
    }
}
