using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace Appointment.Management;

[DependsOn( )]
public class ManagementDomainSharedModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
    }

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<ManagementDomainSharedModule>();
        });

    }
}
