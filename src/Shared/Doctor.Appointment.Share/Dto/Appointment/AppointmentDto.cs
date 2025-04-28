using Doctor.Appointment.Share.Enum;
using System;

namespace Doctor.Appointment.Share.Dto
{
    public class AppointmentDto
    {
        public Guid Id { get; set; }
        public Guid SlotId { get; set; }
        public Guid PatientId { get; set; }
        public string PatientName { get; set; }
        public string PatientEmail { get; set; }
        public DateTime ReservedAt { get; set; }
        public AppointmentStatus? AppointmentStatus { get; set; }
    }
}
