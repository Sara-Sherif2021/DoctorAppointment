using System;
using Volo.Abp;
using Volo.Abp.Application.Dtos;

namespace Doctor.Availability.Share.Dto
{
    public class AvailableSlotResultDto : EntityDto<Guid>
    {
        public DateTime SlotTime { get; set; }
        public int DoctorId { get; set; }
        public string DoctorName { get; set; }
        public string DoctorEmail { get; set; }
        public bool IsReserved { get; set; }
        public decimal Cost { get; set; }
    }
}
