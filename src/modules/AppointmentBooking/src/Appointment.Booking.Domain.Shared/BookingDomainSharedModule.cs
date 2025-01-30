using Volo.Abp.AuditLogging;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace Appointment.Booking;

[DependsOn(
    typeof(AbpAuditLoggingDomainSharedModule)
    )]
public class BookingDomainSharedModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        BookingGlobalFeatureConfigurator.Configure();
        BookingModuleExtensionConfigurator.Configure();
    }

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<BookingDomainSharedModule>();
        });
    }
}
