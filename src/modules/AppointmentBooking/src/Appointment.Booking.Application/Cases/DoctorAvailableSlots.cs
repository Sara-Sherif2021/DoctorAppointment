using Appointment.Booking.DomainServices;
using Appointment.Booking.Dto;
using Doctor.Availability.Share.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace Appointment.Booking.Cases
{
    public class DoctorAvailableSlots : BookingAppService, IScopedDependency
    {
         private readonly IDoctorSlotManager _doctorSlotManager;
        public DoctorAvailableSlots(IDoctorSlotManager doctorSlotManager)
        {
             _doctorSlotManager = doctorSlotManager;
        }
        public async Task<List<DoctorAvailableSlotsDto>> GetDoctorAvailableSlots(int doctorId)
        {
            var availableSlots = await _doctorSlotManager.GetDoctorAvailableSlots(doctorId);
            var result = ObjectMapper.Map<List<AvailableSlotResultDto>, List<DoctorAvailableSlotsDto>>(availableSlots);
            return result;
        }
    }
}
