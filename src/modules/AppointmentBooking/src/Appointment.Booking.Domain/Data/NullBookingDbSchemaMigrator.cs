using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace Appointment.Booking.Data;

/* This is used if database provider does't define
 * IBookingDbSchemaMigrator implementation.
 */
public class NullBookingDbSchemaMigrator : IBookingDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
