using Doctor.Availability.Services;
using Shouldly;
using System.Threading.Tasks;
using Volo.Abp.Modularity;
using Xunit;

namespace Doctor.Availability.SlotTest
{
    public abstract class SlotServiceTest<TStartupModule> : AvailabilityApplicationTestBase<TStartupModule>
        where TStartupModule : IAbpModule
    {
        private readonly ISlotService _slotService;
        protected SlotServiceTest()
        {
            _slotService = GetRequiredService<ISlotService>();
        }

        [Fact]
        public async Task Should_Get_Doctor_Slots()
        {
            //Act
            var slots = await _slotService.GetDoctorSlots(1);

            //Assert
            slots.Count.ShouldBeGreaterThan(0);
        }        
    }
}

