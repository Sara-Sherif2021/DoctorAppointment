using Volo.Abp.Application;
using Volo.Abp.Modularity;

namespace Appointment.Booking.Share;

[DependsOn(
    typeof(AbpDddApplicationContractsModule)
)]
public class ShareApplicationContractsModule : AbpModule
{

}
