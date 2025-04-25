using Doctor.Availability.SlotTest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Doctor.Availability.EntityFrameworkCore.Applications
{
    [Collection(AvailabilityTestConsts.CollectionDefinitionName)]
    public class EfCoreSlotServiceTest: SlotServiceTest<AvailabilityEntityFrameworkCoreTestModule>
    {
    }
}
