using Doctor.Availability.Share.Dto;
using Doctor.Availability.Share.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Services;

namespace Appointment.Booking.DomainServices
{
    public class DoctorSlotManager : DomainService, ITransientDependency, IDoctorSlotManager
    {
        private ISlotIntegration _slotIntegration { get; set; }

        public DoctorSlotManager(ISlotIntegration slotIntegration)
        {
            _slotIntegration = slotIntegration;
        }

        public async Task<List<AvailableSlotResultDto>> GetDoctorAvailableSlots(int doctorId)
        {
            return await _slotIntegration.GetDoctorAvailableSlots(doctorId);
        }

    }
}
