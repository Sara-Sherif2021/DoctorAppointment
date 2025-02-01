using Doctor.Appointment.Share.Enum;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Appointment.Booking.Share
{
    public interface IUpdateAppointmentStatus
    {
        Task ChangeAppointmentStatus(List<Guid> appointments, AppointmentStatus appointmentStatus);
    }
}