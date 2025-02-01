using Xunit;

namespace Appointment.Management.EntityFrameworkCore;

[CollectionDefinition(ManagementTestConsts.CollectionDefinitionName)]
public class ManagementEntityFrameworkCoreCollection : ICollectionFixture<ManagementEntityFrameworkCoreFixture>
{

}
