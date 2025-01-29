using System.Threading.Tasks;

namespace Doctor.Availability.Data;

public interface IAvailabilityDbSchemaMigrator
{
    Task MigrateAsync();
}
