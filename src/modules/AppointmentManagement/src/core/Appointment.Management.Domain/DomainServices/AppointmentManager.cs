using Appointment.Management.Specifications;
using Doctor.Availability.Share.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;

namespace Appointment.Management.DomainServices
{
    public class AppointmentManager : DomainService, ITransientDependency, IAppointmentManager
    {
        private ISlotIntegration _slotIntegration { get; set; }
        private IRepository<Entities.Appointment> _appointmentRepository { get; set; }

        public AppointmentManager(ISlotIntegration slotIntegration
                                    , IRepository<Entities.Appointment> appointmentRepository)
        {
            _slotIntegration = slotIntegration;
            _appointmentRepository = appointmentRepository;
        }


        public async Task<List<Entities.Appointment>> GetUpcomingAppointment(int doctorId)
        {
            List<Entities.Appointment> appointments = null;
            var slots = await _slotIntegration.GetDoctorUpcomingSlots(doctorId);
            if (slots != null && slots.Count > 0)
            {
                var query = await _appointmentRepository.GetQueryableAsync();
                appointments = query.Where(new UpcomingAppointmentFiltration(slots.Select(s => s.Id).ToList()).ToExpression()).ToList();
            }
            return appointments;
        }
    }
}
