using Appointment.Booking.Share;
using Appointment.Booking.Share.Dto;
using Doctor.Appointment.Share.Enum;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace Appointment.Management.Services
{
    public class AppointmentManagementService : ManagementAppService, IScopedDependency
    {
        private IUpcomingAppointment _upcomingAppointment { get; set; }
        private IUpdateAppointmentStatus _updateAppointmentStatus { get; set; }

        public AppointmentManagementService(IUpcomingAppointment upcomingAppointment, IUpdateAppointmentStatus updateAppointmentStatus)
        {
            _upcomingAppointment = upcomingAppointment;
            _updateAppointmentStatus = updateAppointmentStatus;
        }
        public async Task<List<UpcomingAppointmentDto>> GetUpcomingAppointment(int doctorId)
        {
            return await _upcomingAppointment.GetUpcomingAppointment(doctorId);
        }
        public async Task ChangeAppointmentStatus(List<Guid> appointments, AppointmentStatus appointmentStatus)
        {
             await _updateAppointmentStatus.ChangeAppointmentStatus(appointments, appointmentStatus);
        }

    }
}
