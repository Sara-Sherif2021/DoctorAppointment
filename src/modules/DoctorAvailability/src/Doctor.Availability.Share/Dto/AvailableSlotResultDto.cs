using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;

namespace Doctor.Availability.Share.Dto
{
    [IntegrationService]
    public class AvailableSlotResultDto : EntityDto<Guid>
    {
        public DateTime SlotTime { get; set; }
        public int DoctorId { get; set; }
        public bool IsReserved { get; set; }
        public decimal Cost { get; set; }
    }
}
