using Doctor.Appointment.Share.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.EventBus.Distributed;

namespace Doctor.Appointment.Share.Services
{
    public class NotificationService : ShareAppService, INotificationService
    {

        private readonly IDistributedEventBus _distributedEventBus;

        public NotificationService(IDistributedEventBus distributedEventBus)
        {
            _distributedEventBus = distributedEventBus;
        }

        public async Task SendEmail(List<EmailNotificationDto> emailNotification)
        {
            foreach (var emailData in emailNotification)
            {
                await _distributedEventBus.PublishAsync<EmailNotificationDto>(emailData, true);
            }
        }
    }
}
