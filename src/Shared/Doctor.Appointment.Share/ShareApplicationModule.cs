using Volo.Abp.Modularity;
using Volo.Abp.Application;

namespace Doctor.Appointment.Share;

[DependsOn(
    typeof(AbpDddApplicationModule)
)]
public class ShareApplicationModule : AbpModule
{
}
