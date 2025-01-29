using Doctor.Availability.Samples;
using Xunit;

namespace Doctor.Availability.EntityFrameworkCore.Domains;

[Collection(AvailabilityTestConsts.CollectionDefinitionName)]
public class EfCoreSampleDomainTests : SampleDomainTests<AvailabilityEntityFrameworkCoreTestModule>
{

}
