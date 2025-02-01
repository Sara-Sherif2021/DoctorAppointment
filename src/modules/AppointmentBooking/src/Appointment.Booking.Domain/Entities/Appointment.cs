using Ardalis.GuardClauses;
using System;
using Volo.Abp.Domain.Entities;

namespace Appointment.Booking.Entities
{
    public class Appointment : Entity<Guid>
    {

        #region property
        public Guid SlotId { get; set; }
        public Guid PatientId { get; set; }
        public string PatientName { get; set; }
        public string PatientEmail { get; set; }
        public DateTime ReservedAt { get; set; }
        #endregion

        #region Constructors
        public Appointment(Guid id, Guid slotId, Guid patientId, string patientName, string patientEmail, DateTime reservedAt) : base(id)
        {
            ValidateAppointmentData(id, slotId, patientId, patientName, patientEmail, reservedAt);

            SlotId = slotId;
            PatientId = patientId;
            PatientName = patientName;
            PatientEmail = patientEmail;
            ReservedAt = reservedAt;
        }
        #endregion

        #region Public Methods
        
        #endregion

        #region Private Methods
        private void ValidateAppointmentData(Guid id, Guid slotId, Guid patientId, string patientName, string patientEmail, DateTime reservedAt)
        {
            Guard.Against.Default(id, nameof(Id), BookingConsts.InvalidIdErrorMessage);
            Guard.Against.Default(slotId, nameof(slotId), BookingConsts.InvalidSlotIdErrorMessage);
            Guard.Against.Default(patientId, nameof(patientId), BookingConsts.InvalidPatientIdErrorMessage);
            Guard.Against.NullOrEmpty(patientName, nameof(patientName), BookingConsts.EmptyPatientNameErrorMessage);
            Guard.Against.NullOrEmpty(patientEmail, nameof(patientEmail), BookingConsts.EmptyPatientNameErrorMessage);
        }
        #endregion
    }
}
