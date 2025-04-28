using Ardalis.GuardClauses;
using Doctor.Appointment.Share.Consts;
using Doctor.Appointment.Share.Enum;
using System;
using Volo.Abp.Domain.Entities;

namespace Appointment.Management.Entities
{
    public class Appointment : Entity<Guid>
    {

        #region property
        public Guid SlotId { get; set; }
        public Guid PatientId { get; set; }
        public string PatientName { get; set; }
        public string PatientEmail { get; set; }
        public DateTime ReservedAt { get; set; }
        public AppointmentStatus? AppointmentStatus { get; set; }
        #endregion

        #region Constructors
        public Appointment(Guid id, Guid slotId, Guid patientId, string patientName, string patientEmail, DateTime reservedAt, AppointmentStatus? appointmentStatus = null) : base(id)
        {
            ValidateAppointmentData(id, slotId, patientId, patientName, patientEmail, reservedAt);

            SlotId = slotId;
            PatientId = patientId;
            PatientName = patientName;
            PatientEmail = patientEmail;
            ReservedAt = reservedAt;
            AppointmentStatus = appointmentStatus;
        }
        #endregion

        #region Public Methods
        public void ChangeAppointmentStatus(AppointmentStatus appointmentStatus) {
            AppointmentStatus = appointmentStatus;
        }
        #endregion

        #region Private Methods
        private void ValidateAppointmentData(Guid id, Guid slotId, Guid patientId, string patientName, string patientEmail, DateTime reservedAt)
        {
            Guard.Against.Default(id, nameof(Id), DoctorAppointmentConsts.InvalidIdErrorMessage);
            Guard.Against.Default(slotId, nameof(slotId), DoctorAppointmentConsts.InvalidSlotIdErrorMessage);
            Guard.Against.Default(patientId, nameof(patientId), DoctorAppointmentConsts.InvalidPatientIdErrorMessage);
            Guard.Against.NullOrEmpty(patientName, nameof(patientName), DoctorAppointmentConsts.EmptyPatientNameErrorMessage);
            Guard.Against.NullOrEmpty(patientEmail, nameof(patientEmail), DoctorAppointmentConsts.EmptyPatientEmailErrorMessage);
        }
        #endregion
    }
}
