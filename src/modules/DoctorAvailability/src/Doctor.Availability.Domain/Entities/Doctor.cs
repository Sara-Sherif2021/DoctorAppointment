using System.Collections.Generic;
using Volo.Abp.Domain.Entities;

namespace Doctor.Availability.Entities
{
    public class Doctor : Entity<int>
    {
        public string Name { get; set; }
        public string? Specializations { get; set; }
        public virtual ICollection<Slot> Slots { get; set; }
    }
}
