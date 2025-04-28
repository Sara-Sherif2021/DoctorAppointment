using Doctor.Appointment.Share.Dto;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.EventBus.Distributed;

namespace Appointment.Management.Events
{
    public class CreateAppointmentEventHandler : IDistributedEventHandler<AppointmentDto>, ITransientDependency
    {
        private IRepository<Entities.Appointment> _appointmentRepository { get; set; }
        private readonly ILogger<CreateAppointmentEventHandler> _logger;
        public CreateAppointmentEventHandler(IRepository<Entities.Appointment> appointmentRepository, ILogger<CreateAppointmentEventHandler> logger)
        {
            _appointmentRepository = appointmentRepository;
            _logger = logger;
        }
        public async Task HandleEventAsync(AppointmentDto appointment)
        {
            _logger.LogInformation("New appointment has been received");
            var createdAppointment = new Entities.Appointment(appointment.Id, appointment.SlotId, appointment.PatientId, appointment.PatientName, appointment.PatientEmail, appointment.ReservedAt);
            if (createdAppointment != null)
            {
                await _appointmentRepository.InsertAsync(createdAppointment);
            }
            //handle createdAppointment = null case
        }
    }
}
