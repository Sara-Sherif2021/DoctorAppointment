namespace Doctor.Appointment.Share.Dto
{
    public class EmailNotificationDto
    {
        public string ReceiverEmail { get; set; }
        public string EmailSubject { get; set; }
        public string EmailContent { get; set; }
    }
}
