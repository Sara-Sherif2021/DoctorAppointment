using Appointment.Booking.Specifications;
using Doctor.Appointment.Share.Dto;
using Doctor.Appointment.Share.Enum;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.EventBus.Distributed;

namespace Appointment.Booking.Events
{
    public class ChangeAppointmentStatusEventHandler : IDistributedEventHandler<ChangeAppointmentStatusDto>, ITransientDependency
    {
        private IRepository<Entities.Appointment> _appointmentRepository { get; set; }
        private readonly ILogger<ChangeAppointmentStatusEventHandler> _logger;
        public ChangeAppointmentStatusEventHandler(IRepository<Entities.Appointment> appointmentRepository, ILogger<ChangeAppointmentStatusEventHandler> logger)
        {
            _appointmentRepository = appointmentRepository;
            _logger = logger;
        }
        public async Task HandleEventAsync(ChangeAppointmentStatusDto changeAppointmentStatus)
        {
            _logger.LogInformation("New appointment has been received");
            var query = await _appointmentRepository.GetQueryableAsync();
            var appointments = query.Where(new AppointmentListFiltration(changeAppointmentStatus.AppointmentIds)).ToList();
            appointments.ForEach(appointment =>
            {
                appointment.ChangeAppointmentStatus(changeAppointmentStatus.AppointmentStatus);
            });
            await _appointmentRepository.UpdateManyAsync(appointments);
        }
    }
}
