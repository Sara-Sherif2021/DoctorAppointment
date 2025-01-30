using System;
using System.Threading.Tasks;
using Shouldly;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace Doctor.Availability.EntityFrameworkCore.Samples;

/* This is just an example test class.
 * Normally, you don't test ABP framework code
 * Only test your custom repository methods.
 */
[Collection(AvailabilityTestConsts.CollectionDefinitionName)]
public class SampleRepositoryTests : AvailabilityEntityFrameworkCoreTestBase
{
}
