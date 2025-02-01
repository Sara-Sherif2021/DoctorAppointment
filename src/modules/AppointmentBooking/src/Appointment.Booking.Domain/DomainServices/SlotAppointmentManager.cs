using Doctor.Availability.Share.Dto;
using Doctor.Availability.Share.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Services;
using Doctor.Appointment.Share.Services;
using Doctor.Appointment.Share.Dto;

namespace Appointment.Booking.DomainServices
{
    public class SlotAppointmentManager : DomainService, ITransientDependency, ISlotAppointmentManager
    {
        private ISlotIntegration _slotIntegration { get; set; }
        private INotificationService _notificationService { get; set; }

        public SlotAppointmentManager(ISlotIntegration slotIntegration, INotificationService notificationService)
        {
            _slotIntegration = slotIntegration;
            _notificationService = notificationService;
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
                    await SendConfirmationEmailData(patientEmail, slot.DoctorEmail, slot.SlotTime);

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
        private async Task SendConfirmationEmailData(string patientEmail, string doctorEmail, DateTime slotTime)
        {
            var emailData = new List<EmailNotificationDto>() {
           new EmailNotificationDto { ReceiverEmail = patientEmail, EmailSubject="Appointment Confirmation", EmailContent = $"Your appointment has been booked at {slotTime.ToString()} " },
           new EmailNotificationDto { ReceiverEmail = doctorEmail, EmailSubject="Appointment Confirmation", EmailContent = $"New appointment has been booked at {slotTime.ToString()} " } };

            await _notificationService.SendEmail(emailData);
        }
    }
}
