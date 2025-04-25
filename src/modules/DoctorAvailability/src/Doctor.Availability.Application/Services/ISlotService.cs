using Doctor.Availability.Dto.Slot;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace Doctor.Availability.Services
{
    public interface ISlotService : IScopedDependency
    {
        Task<List<SlotDto>> GetDoctorSlots(int doctorId);
    }
}