using Appointment.Booking.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace Appointment.Booking.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(BookingEntityFrameworkCoreModule),
    typeof(BookingApplicationContractsModule)
)]
public class BookingDbMigratorModule : AbpModule
{
}
