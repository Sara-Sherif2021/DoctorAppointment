using Doctor.Appointment.Share.Consts;
using Doctor.Appointment.Share.Dto;
using Doctor.Appointment.Share.Services;
using Doctor.Availability.Share.Interfaces;
using System;
using System.Collections.Generic;
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
        private IEventService<List<EmailNotificationDto>> _emailEventService { get; set; }
        private IEventService<AppointmentDto> _appointmentEventService { get; set; }
        private IRepository<Entities.Appointment> _appointmentRepository { get; set; }

        public SlotAppointmentManager(ISlotIntegration slotIntegration
                                    , IEventService<List<EmailNotificationDto>> emailEventService
                                    , IRepository<Entities.Appointment> appointmentRepository
                                    , IEventService<AppointmentDto> appointmentEventService)
        {
            _slotIntegration = slotIntegration;
            _emailEventService = emailEventService;
            _appointmentRepository = appointmentRepository;
            _appointmentEventService = appointmentEventService;
        }


        public async Task<Entities.Appointment> CreateAppointment(Guid id, Guid slotId, Guid patientId, string patientName, string patientEmail, DateTime reservedAt)
        {
            if (slotId != Guid.Empty)
            {
                var slot = await _slotIntegration.GetAvailableSlotById(slotId);
                if (slot != null)
                {
                    var createdAppointment = new Entities.Appointment(id, slotId, patientId, patientName, patientEmail, reservedAt);
                    var addedAppointment = await _appointmentRepository.InsertAsync(createdAppointment);
                    if (addedAppointment != null)
                    {
                        //Raise created Appointment event
                        await _appointmentEventService.PublishEventAsync(new AppointmentDto
                        {
                            Id = id,
                            SlotId = slotId,
                            PatientId = patientId,
                            PatientName = patientName,
                            PatientEmail = patientEmail,
                            ReservedAt = reservedAt
                        }); //ToDo: use automapper

                        //send notification
                        await SendConfirmationEmailData(patientEmail, slot.DoctorEmail, patientName, slot.DoctorName, slot.SlotTime);
                    }

                    return addedAppointment;
                }
                {
                    throw new EntityNotFoundException(DoctorAppointmentConsts.InvalidSlotIdErrorMessage);
                }
            }
            else
            {
                throw new EntityNotFoundException(DoctorAppointmentConsts.InvalidSlotIdErrorMessage);
            }
        }
        private async Task SendConfirmationEmailData(string patientEmail, string doctorEmail, string patientName, string doctorName, DateTime slotTime)
        {
            string emailBody = $"New appointment has been booked for patient {patientName} with doctor {doctorName} at {slotTime.ToString()}";
            var emailData = new List<EmailNotificationDto>() {
           new EmailNotificationDto { ReceiverEmail = patientEmail, EmailSubject="Appointment Confirmation", EmailContent = emailBody},
           new EmailNotificationDto { ReceiverEmail = doctorEmail, EmailSubject="Appointment Confirmation", EmailContent = emailBody} };

            await _emailEventService.PublishEventAsync(emailData);
        }
    }
}
