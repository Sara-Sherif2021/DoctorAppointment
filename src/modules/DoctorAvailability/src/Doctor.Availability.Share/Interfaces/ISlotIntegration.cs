using Doctor.Availability.Share.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Services;

namespace Doctor.Availability.Share.Interfaces
{
    public interface ISlotIntegration
    {
        Task<AvailableSlotResultDto> GetAvailableSlotById(Guid slotId);
        Task<List<AvailableSlotResultDto>> GetDoctorAvailableSlots(int doctorId);
       // Task<bool> IsSlotAvailable(Guid slotId);
    }
}
