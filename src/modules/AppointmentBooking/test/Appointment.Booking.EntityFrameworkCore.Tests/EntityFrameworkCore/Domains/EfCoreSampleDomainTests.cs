using Appointment.Booking.Samples;
using Xunit;

namespace Appointment.Booking.EntityFrameworkCore.Domains;

[Collection(BookingTestConsts.CollectionDefinitionName)]
public class EfCoreSampleDomainTests : SampleDomainTests<BookingEntityFrameworkCoreTestModule>
{

}
