using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.EventBus.Distributed;
using Doctor.Appointment.Notification;
using Doctor.Appointment.Share.Dto;
using Volo.Abp.Emailing;
using Microsoft.Extensions.Logging;

namespace Doctor.Appointment.Notification.Handlers
{
    public class EmailNotificationEventHandler : IDistributedEventHandler<EmailNotificationDto>, ITransientDependency
    {
        private readonly IEmailSender _emailSender;
        private readonly ILogger<EmailNotificationEventHandler> _logger;
        public EmailNotificationEventHandler(IEmailSender emailSender, ILogger<EmailNotificationEventHandler> logger = null)
        {
            _emailSender = emailSender;
            _logger = logger;
        }

        public async Task HandleEventAsync(EmailNotificationDto emailNotification)
        {
            _logger.LogInformation($"New email EmailSubject: {emailNotification.EmailSubject},  ReceiverEmail: {emailNotification.ReceiverEmail}, EmailContent: {emailNotification.EmailContent}"); 
           // await _emailSender.SendAsync(
           //    emailNotification.ReceiverEmail,     // target email address
           //    emailNotification.EmailSubject,      // subject
           //    emailNotification.EmailContent      // email body
           //);
        }
    }
}
