using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace Appointment.Management.Dto
{
    public class UpcomingAppointmentDto : EntityDto<Guid>
    {
        public Guid SlotId { get; set; }
        public Guid PatientId { get; set; }
        public string PatientName { get; set; }
        public string PatientEmail { get; set; }
        public DateTime ReservedAt { get; set; }

    }
}
