using Appointment.Booking.DomainServices;
using Appointment.Booking.Share;
using Appointment.Booking.Specifications;
using Doctor.Appointment.Share.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;

namespace Appointment.Booking.Cases
{
    [IntegrationService]
    public class UpdateAppointmentStatus : BookingAppService, IScopedDependency, IUpdateAppointmentStatus
    {
        private readonly ISlotAppointmentManager _sotAppointmentManager;
        private readonly IRepository<Entities.Appointment> _appointmentRepository;

        public UpdateAppointmentStatus(ISlotAppointmentManager sotAppointmentManager, IRepository<Entities.Appointment> appointmentRepository)
        {
            _sotAppointmentManager = sotAppointmentManager;
            _appointmentRepository = appointmentRepository;
        }

        public async Task ChangeAppointmentStatus(List<Guid> appointmentIds, AppointmentStatus appointmentStatus)
        {
            var query = await _appointmentRepository.GetQueryableAsync();
            var appointments = query.Where(new AppointmentListFiltration(appointmentIds)).ToList();
            appointments.ForEach(appointment => { 
                appointment.AppointmentStatus = appointmentStatus;
            });
           await _appointmentRepository.UpdateManyAsync(appointments);
        }
    }
}
