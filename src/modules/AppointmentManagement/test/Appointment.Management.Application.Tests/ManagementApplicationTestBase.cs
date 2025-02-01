using Volo.Abp.Modularity;

namespace Appointment.Management;

public abstract class ManagementApplicationTestBase<TStartupModule> : ManagementTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
