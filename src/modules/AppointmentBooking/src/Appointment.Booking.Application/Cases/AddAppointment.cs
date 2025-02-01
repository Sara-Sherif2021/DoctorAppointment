using Appointment.Booking.DomainServices;
using Appointment.Booking.Dto;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;

namespace Appointment.Booking.Cases
{
    public class AddAppointment : BookingAppService, IScopedDependency
    {
        private readonly ISlotAppointmentManager _sotAppointmentManager;
        public IRepository<Entities.Appointment> _appointmentRepository { get; set; }

        public AddAppointment(ISlotAppointmentManager sotAppointmentManager, IRepository<Entities.Appointment> appointmentRepository)
        {
            _sotAppointmentManager = sotAppointmentManager;
            _appointmentRepository = appointmentRepository;
        }

        public async Task<AppointmentDto> CreateAppointment(AppointmentDto appointment)
        {
            AppointmentDto result = null;
            var appointmentEntity = await _sotAppointmentManager.CreateAppointment(appointment.Id, appointment.SlotId, appointment.PatientId, appointment.PatientName,appointment.PatientEmail, appointment.ReservedAt);
            var addedAppointment = await _appointmentRepository.InsertAsync(appointmentEntity);
            if (addedAppointment != null)
            {
                result = ObjectMapper.Map<Entities.Appointment, AppointmentDto>(addedAppointment);
            }
            return result;
        }
    }
}
