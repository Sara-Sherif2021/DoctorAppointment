using Doctor.Availability.Share.Dto;
using Doctor.Availability.Share.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Services;

namespace Appointment.Booking.DomainServices
{
    public class SlotAppointmentManager : DomainService, ITransientDependency, ISlotAppointmentManager
    {
        private ISlotIntegration _slotIntegration { get; set; }

        public SlotAppointmentManager(ISlotIntegration slotIntegration)
        {
            _slotIntegration = slotIntegration;
        }


        public async Task<Entities.Appointment> CreateAppointment(Guid id, Guid slotId, Guid patientId, string patientName, string patientEmail, DateTime reservedAt)
        {
            if (slotId != Guid.Empty)
            {
                var slot = await _slotIntegration.GetAvailableSlotById(slotId);
                if (slot != null)
                {
                    var createdAppointment = new Entities.Appointment(id, slotId, patientId, patientName, patientEmail, reservedAt);
                    //send notification
                    return createdAppointment;
                }
                {
                    throw new EntityNotFoundException(BookingConsts.InvalidSlotIdErrorMessage);
                }
            }
            else
            {
                throw new EntityNotFoundException(BookingConsts.InvalidSlotIdErrorMessage);
            }
        }
    }
}
