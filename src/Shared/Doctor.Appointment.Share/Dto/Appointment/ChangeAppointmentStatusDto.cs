using Doctor.Appointment.Share.Enum;
using System;
using System.Collections.Generic;

namespace Doctor.Appointment.Share.Dto
{
    public class ChangeAppointmentStatusDto
    {
        public List<Guid> AppointmentIds { get; set; }
        public AppointmentStatus AppointmentStatus { get; set; }
    }
}
