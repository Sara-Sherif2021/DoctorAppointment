using Doctor.Availability.Share.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Appointment.Booking.DomainServices
{
    public interface IDoctorSlotManager
    {
        Task<List<AvailableSlotResultDto>> GetDoctorAvailableSlots(int doctorId);
    }
}