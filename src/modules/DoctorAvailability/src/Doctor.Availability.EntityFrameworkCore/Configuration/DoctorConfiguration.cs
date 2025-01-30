using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Doctor.Availability.Configuration
{
    public class DoctorConfiguration : IEntityTypeConfiguration<Entities.Doctor>
    {
        public void Configure(EntityTypeBuilder<Entities.Doctor> builder)
        {
            builder.HasIndex(n => n.Name).IsUnique();
        }
    }
}
