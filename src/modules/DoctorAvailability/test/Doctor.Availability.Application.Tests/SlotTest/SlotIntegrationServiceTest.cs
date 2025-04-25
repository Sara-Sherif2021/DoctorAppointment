using Doctor.Availability.Services;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Modularity;
using Xunit;

namespace Doctor.Availability.SlotTest
{
    public abstract class SlotIntegrationServiceTest<TStartupModule> : AvailabilityApplicationTestBase<TStartupModule>
        where TStartupModule : IAbpModule
    {
        private readonly ISlotIntegrationService _slotIntegrationService;
        protected SlotIntegrationServiceTest( )
        {
            _slotIntegrationService = GetRequiredService<ISlotIntegrationService>(); ;
        }

        [Fact]
        public async Task Should_Get_Doctor_Available_Slots()
        {
            //Act
            var slots = await _slotIntegrationService.GetDoctorAvailableSlots(1);

            //Assert
            slots.Count.ShouldBe(1);
        }
    }
}
