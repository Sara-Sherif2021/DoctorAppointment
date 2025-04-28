using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Appointment.Management.DomainServices
{
    public interface IAppointmentManager
    {
        Task<List<Entities.Appointment>> GetUpcomingAppointment(int doctorId);
    }
}