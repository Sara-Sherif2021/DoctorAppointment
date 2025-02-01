using System;
using System.Threading.Tasks;

namespace Appointment.Booking.DomainServices
{
    public interface ISlotAppointmentManager
    {
        Task<Entities.Appointment> CreateAppointment(Guid id, Guid slotId, Guid patientId, string patientName, string patientEmail, DateTime reservedAt);
    }
}