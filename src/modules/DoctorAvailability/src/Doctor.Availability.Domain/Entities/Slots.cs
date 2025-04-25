using System;
using Volo.Abp.Domain.Entities;

namespace Doctor.Availability.Entities
{
    public class Slot : Entity<Guid>
    {
        public Slot(Guid id, DateTime slotTime, int doctorId, bool isReserved, decimal? cost)
        {
            Id = id;
            SlotTime = slotTime;
            DoctorId = doctorId;
            IsReserved = isReserved;
            Cost = cost;
        }

        public DateTime SlotTime { get; set; }
        public int DoctorId { get; set; }
        public bool IsReserved { get; set; }
        public decimal? Cost { get; set; }
        public virtual Doctor Doctor { get; set; }
    }
}
