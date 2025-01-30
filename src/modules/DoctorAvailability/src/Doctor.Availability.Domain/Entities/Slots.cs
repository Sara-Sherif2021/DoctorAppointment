using System;
using Volo.Abp.Domain.Entities;

namespace Doctor.Availability.Entities
{
    public class Slot : Entity<Guid>
    {
        public DateTime SlotTime { get; set; }
        public int DoctorId { get; set; }
        public bool IsReserved { get; set; }
        public decimal? Cost { get; set; }
        public virtual Doctor Doctor { get; set; }
    }
}
