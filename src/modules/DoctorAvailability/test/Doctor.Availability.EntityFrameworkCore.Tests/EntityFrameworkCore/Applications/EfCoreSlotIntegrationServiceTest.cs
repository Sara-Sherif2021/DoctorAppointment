using Doctor.Availability.SlotTest;
using Xunit;

namespace Doctor.Availability.EntityFrameworkCore.Applications
{
    [Collection(AvailabilityTestConsts.CollectionDefinitionName)]
    public class EfCoreIssueAppService_Tests : SlotIntegrationServiceTest<AvailabilityEntityFrameworkCoreTestModule>
    {

    }
}
