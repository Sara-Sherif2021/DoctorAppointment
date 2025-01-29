using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace Doctor.Availability.Data;

/* This is used if database provider does't define
 * IAvailabilityDbSchemaMigrator implementation.
 */
public class NullAvailabilityDbSchemaMigrator : IAvailabilityDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
