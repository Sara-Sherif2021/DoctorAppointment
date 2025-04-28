using System;
using Doctor.Availability.Share.Interfaces;
using NSubstitute;
using Reqnroll;
using Volo.Abp.Modularity;
using Doctor.Availability.Share.Dto;
using Appointment.Booking.DomainServices;
using Doctor.Appointment.Share.Services;
using Volo.Abp.Domain.Repositories;
using Doctor.Appointment.Share.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;
using Shouldly;
using NSubstitute.ReturnsExtensions;

namespace Appointment.Booking.BookAppointment
{
    [Binding]
    public class BookAppointmentStepDefinitions
   
    {
        private ISlotAppointmentManager _slotAppointmentManager;
        private ISlotIntegration _slotIntegration;
        private IEventService<List<EmailNotificationDto>> _eventService { get; set; }
        private IRepository<Entities.Appointment> _appointmentRepository { get; set; }
        private Entities.Appointment _createdAppointment { get; set; }
        public BookAppointmentStepDefinitions()
        {
            _appointmentRepository = Substitute.For<IRepository<Entities.Appointment>>();
            _eventService = Substitute.For<IEventService<List<EmailNotificationDto>>>();
            _eventService.PublishEventAsync(Arg.Any<List<EmailNotificationDto>>()).Returns(Task.CompletedTask);

        }

        [Given("The slot with slotId {string} is a free slot")]
        public void GivenTheSlotWithSlotIdIsAFreeSlot(string slotId)
        {
            _slotIntegration = Substitute.For<ISlotIntegration>();
            _slotIntegration.GetAvailableSlotById(new Guid(slotId)).Returns(new AvailableSlotResultDto { Id = new Guid(slotId) });

        }
        [When("when the patient try to book this slot using below data")]
        public async Task WhenWhenThePatientTryToBookThisSlotUsingBelowData(DataTable dataTable)
        {
            _slotAppointmentManager = new SlotAppointmentManager(_slotIntegration, _eventService, _appointmentRepository);
            var appointmentTable = dataTable.CreateInstance<(Guid id, Guid slotId, Guid patientId, string patientName, string patientEmail, DateTime reservedAt)>();
            _createdAppointment = await _slotAppointmentManager.CreateAppointment(appointmentTable.id, appointmentTable.slotId, appointmentTable.patientId,
                appointmentTable.patientName, appointmentTable.patientEmail, appointmentTable.reservedAt);
        }

        [Then("The slot with slotId {string} will be booked correctly")]
        public void ThenTheSlotWithSlotIdWillBeBookedCorrectly(string slotId)
        {
            _createdAppointment.ShouldNotBeNull();
            _createdAppointment.SlotId.ShouldBe(new Guid(slotId));
        }
    }
}
