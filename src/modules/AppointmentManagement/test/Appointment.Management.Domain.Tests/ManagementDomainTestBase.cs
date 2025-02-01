using Volo.Abp.Modularity;

namespace Appointment.Management;

/* Inherit from this class for your domain layer tests. */
public abstract class ManagementDomainTestBase<TStartupModule> : ManagementTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
