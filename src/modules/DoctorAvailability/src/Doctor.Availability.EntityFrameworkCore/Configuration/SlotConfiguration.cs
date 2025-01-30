using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Doctor.Availability.Configuration
{
    public class SlotConfiguration : IEntityTypeConfiguration<Entities.Slot>
    {
        public void Configure(EntityTypeBuilder<Entities.Slot> builder)
        {
            builder.HasOne<Entities.Doctor>(a => a.Doctor)
           .WithMany(b => b.Slots)
           .HasForeignKey(o => o.DoctorId)
           .IsRequired();
        }
    }
}
