using Appointment.Booking.Share.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Appointment.Booking.Share
{
    public interface IUpcomingAppointment
    {
        Task<List<UpcomingAppointmentDto>> GetUpcomingAppointment(int doctorId);
    }
}