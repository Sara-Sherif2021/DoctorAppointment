using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace Doctor.Availability.Dto.Slot
{
    public class SlotDto : EntityDto<Guid>
    {
        public DateTime SlotTime { get; set; }
        public int DoctorId { get; set; }
        public bool IsReserved { get; set; }
        public decimal Cost { get; set; }
    }
}
