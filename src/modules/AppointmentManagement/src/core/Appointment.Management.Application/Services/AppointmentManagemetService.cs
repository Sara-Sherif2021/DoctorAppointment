using Appointment.Management.DomainServices;
using Appointment.Management.Dto;
using Appointment.Management.Specifications;
using Doctor.Appointment.Share.Dto;
using Doctor.Appointment.Share.Enum;
using Doctor.Appointment.Share.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;

namespace Appointment.Management.Services
{
    public class AppointmentManagementService : ManagementAppService, IScopedDependency
    {
        private readonly IAppointmentManager _sotAppointmentManager;

        private readonly IRepository<Entities.Appointment> _appointmentRepository;
        private IEventService<ChangeAppointmentStatusDto> _appointmentStatusEventService { get; set; }

        public AppointmentManagementService(IAppointmentManager sotAppointmentManager, IRepository<Entities.Appointment> appointmentRepository, IEventService<ChangeAppointmentStatusDto> appointmentStatusEventService)
        {
            _sotAppointmentManager = sotAppointmentManager;
            _appointmentRepository = appointmentRepository;
            _appointmentStatusEventService = appointmentStatusEventService;
        }
        public async Task<List<UpcomingAppointmentDto>> GetUpcomingAppointment(int doctorId)
        {
            List<UpcomingAppointmentDto> result = null;
            var upcomingAppointments = await _sotAppointmentManager.GetUpcomingAppointment(doctorId);
            if (upcomingAppointments != null)
            {
                result = ObjectMapper.Map<List<Entities.Appointment>, List<UpcomingAppointmentDto>>(upcomingAppointments);
            }
            return result;
        }
        public async Task ChangeAppointmentStatus(List<Guid> appointmentIds, AppointmentStatus appointmentStatus)
        {
            var query = await _appointmentRepository.GetQueryableAsync();
            var appointments = query.Where(new AppointmentListFiltration(appointmentIds)).ToList();
            appointments.ForEach(appointment =>
            {
                appointment.ChangeAppointmentStatus(appointmentStatus);
            });
            await _appointmentRepository.UpdateManyAsync(appointments);

            await _appointmentStatusEventService.PublishEventAsync(new ChangeAppointmentStatusDto { AppointmentIds = appointmentIds, AppointmentStatus = appointmentStatus });

        }

    }
}
