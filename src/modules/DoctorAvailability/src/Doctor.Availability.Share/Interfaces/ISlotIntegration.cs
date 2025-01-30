using Doctor.Availability.Share.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;

namespace Doctor.Availability.Share.Interfaces
{
    [IntegrationService]
    public interface ISlotIntegration
    {
        Task<List<AvailableSlotResultDto>> GetDoctorAvailableSlots(int doctorId);
        Task<bool> IsSlotAvailable(Guid slotId);
    }
}
