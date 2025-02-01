using Doctor.Appointment.Share.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Doctor.Appointment.Share.Services
{
    public interface INotificationService
    {
        Task SendEmail(List<EmailNotificationDto> emailNotification);
    }
}