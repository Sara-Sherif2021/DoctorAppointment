using System.Threading.Tasks;

namespace Appointment.Booking.Data;

public interface IBookingDbSchemaMigrator
{
    Task MigrateAsync();
}
