using Volo.Abp.AutoMapper;
using Volo.Abp.Emailing;
using Volo.Abp.Modularity;

namespace Doctor.Appointment.Notification;

[DependsOn(
    typeof(AbpAutoMapperModule),
    typeof(AbpEmailingModule)
    )]
public class NotificationApplicationModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpAutoMapperOptions>(options =>
        {
            options.AddMaps<NotificationApplicationModule>();
        });
    }
}
