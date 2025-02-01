using Appointment.Booking.DomainServices;
using Appointment.Booking.Share;
using Appointment.Booking.Share.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.DependencyInjection;

namespace Appointment.Booking.Cases
{
    [IntegrationService]
    public class UpcomingAppointment : BookingAppService, IScopedDependency, IUpcomingAppointment
    {
        private readonly ISlotAppointmentManager _sotAppointmentManager;

        public UpcomingAppointment(ISlotAppointmentManager sotAppointmentManager)
        {
            _sotAppointmentManager = sotAppointmentManager;
        }

        public async Task<List<UpcomingAppointmentDto>> GetUpcomingAppointment(int doctorId)
        {
            List<UpcomingAppointmentDto> result = null;
            var appointmentEntity = await _sotAppointmentManager.GetUpcomingAppointment(doctorId);
            if (appointmentEntity != null)
            {
                result = ObjectMapper.Map<List<Entities.Appointment>, List<UpcomingAppointmentDto>>(appointmentEntity);
            }
            return result;
        }
    }
}
