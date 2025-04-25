using System.Collections.Generic;
using Volo.Abp.Domain.Entities;

namespace Doctor.Availability.Entities
{
    public class Doctor : Entity<int>
    {
        public Doctor(int id, string name, string email, string? specializations)
        {
            Id = id;
            Name = name;
            Email = email;
            Specializations = specializations;
        }

        public string Name { get; set; }
        public string Email { get; set; }
        public string? Specializations { get; set; }
        public virtual ICollection<Slot> Slots { get; set; }
    }
}
