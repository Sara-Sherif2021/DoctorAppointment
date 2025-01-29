using Xunit;

namespace Doctor.Availability.EntityFrameworkCore;

[CollectionDefinition(AvailabilityTestConsts.CollectionDefinitionName)]
public class AvailabilityEntityFrameworkCoreCollection : ICollectionFixture<AvailabilityEntityFrameworkCoreFixture>
{

}
