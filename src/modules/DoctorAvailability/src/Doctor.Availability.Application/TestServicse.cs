using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace Doctor.Availability
{
    public class TestServicse:AvailabilityAppService, IScopedDependency
    {
        public string GetMesg() {
            return "Hello";
        }
    }
}
