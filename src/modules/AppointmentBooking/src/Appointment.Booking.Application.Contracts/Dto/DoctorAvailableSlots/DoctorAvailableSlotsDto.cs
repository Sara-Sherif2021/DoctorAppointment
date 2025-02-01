using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointment.Booking.Dto
{
    public class DoctorAvailableSlotsDto
    {
        public Guid Id { get; set; }
        public DateTime SlotTime { get; set; }
        public int DoctorId { get; set; }
        public string DoctorName { get; set; }
        public bool IsReserved { get; set; }
        public decimal Cost { get; set; }
    }
}
