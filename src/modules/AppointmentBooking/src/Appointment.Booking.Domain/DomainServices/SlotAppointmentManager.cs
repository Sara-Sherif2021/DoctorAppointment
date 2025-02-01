using Appointment.Booking.Specifications;
using Doctor.Appointment.Share.Dto;
using Doctor.Appointment.Share.Services;
using Doctor.Availability.Share.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;

namespace Appointment.Booking.DomainServices
{
    public class SlotAppointmentManager : DomainService, ITransientDependency, ISlotAppointmentManager
    {
        private ISlotIntegration _slotIntegration { get; set; }
        private INotificationService _notificationService { get; set; }
        private IRepository<Entities.Appointment> _appointmentRepository { get; set; }

        public SlotAppointmentManager(ISlotIntegration slotIntegration, INotificationService notificationService, IRepository<Entities.Appointment> appointmentRepository)
        {
            _slotIntegration = slotIntegration;
            _notificationService = notificationService;
            _appointmentRepository = appointmentRepository;
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
        public async Task<List<Entities.Appointment>> GetUpcomingAppointment(int doctorId)
        {
            List<Entities.Appointment> appointments = null;
            var slots = await _slotIntegration.GetDoctorUpcomingSlots(doctorId);
            if (slots!=null && slots.Count>0)
            {
                var query = await _appointmentRepository.GetQueryableAsync();
                appointments= query.Where(new UpcomingAppointmentFiltration(slots.Select(s=>s.Id).ToList()).ToExpression()).ToList();
            }
            return appointments;
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
