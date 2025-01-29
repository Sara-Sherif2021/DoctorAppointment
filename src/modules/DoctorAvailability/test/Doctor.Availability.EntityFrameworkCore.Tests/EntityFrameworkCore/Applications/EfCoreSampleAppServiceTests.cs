using Doctor.Availability.Samples;
using Xunit;

namespace Doctor.Availability.EntityFrameworkCore.Applications;

[Collection(AvailabilityTestConsts.CollectionDefinitionName)]
public class EfCoreSampleAppServiceTests : SampleAppServiceTests<AvailabilityEntityFrameworkCoreTestModule>
{

}
