using System.Threading.Tasks;

namespace Appointment.Management.Data;

public interface IManagementDbSchemaMigrator
{
    Task MigrateAsync();
}
