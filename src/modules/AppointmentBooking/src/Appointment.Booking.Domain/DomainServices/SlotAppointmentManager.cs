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
using Microsoft.Extensions.Hosting;

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
                    await SendConfirmationEmailData(patientEmail, slot.DoctorEmail, patientName, slot.DoctorName, slot.SlotTime);

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
        private async Task SendConfirmationEmailData(string patientEmail, string doctorEmail, string patientName, string doctorName, DateTime slotTime)
        {
            string emailBody = $"New appointment has been booked for patient {patientName} with doctor {doctorName} at {slotTime.ToString()}";
            var emailData = new List<EmailNotificationDto>() {
           new EmailNotificationDto { ReceiverEmail = patientEmail, EmailSubject="Appointment Confirmation", EmailContent = emailBody},
           new EmailNotificationDto { ReceiverEmail = doctorEmail, EmailSubject="Appointment Confirmation", EmailContent = emailBody} };

            await _notificationService.SendEmail(emailData);
        }
    }
}
