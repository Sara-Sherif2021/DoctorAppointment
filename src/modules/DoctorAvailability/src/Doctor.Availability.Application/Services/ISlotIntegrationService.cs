using Doctor.Availability.Share.Dto;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace Doctor.Availability.Services
{
    public interface ISlotIntegrationService : IScopedDependency
    {
        Task<AvailableSlotResultDto> GetAvailableSlotById(Guid slotId);
        Task<List<AvailableSlotResultDto>> GetDoctorAvailableSlots(int doctorId);
        Task<List<UpcomingSlotResultDto>> GetDoctorUpcomingSlots(int doctorId);
    }
}