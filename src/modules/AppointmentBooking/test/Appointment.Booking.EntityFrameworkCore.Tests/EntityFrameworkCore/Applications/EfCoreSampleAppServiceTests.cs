using Appointment.Booking.Samples;
using Xunit;

namespace Appointment.Booking.EntityFrameworkCore.Applications;

[Collection(BookingTestConsts.CollectionDefinitionName)]
public class EfCoreSampleAppServiceTests : SampleAppServiceTests<BookingEntityFrameworkCoreTestModule>
{

}
