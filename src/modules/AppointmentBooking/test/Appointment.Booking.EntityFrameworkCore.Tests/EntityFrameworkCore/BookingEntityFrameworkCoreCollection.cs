using Xunit;

namespace Appointment.Booking.EntityFrameworkCore;

[CollectionDefinition(BookingTestConsts.CollectionDefinitionName)]
public class BookingEntityFrameworkCoreCollection : ICollectionFixture<BookingEntityFrameworkCoreFixture>
{

}
