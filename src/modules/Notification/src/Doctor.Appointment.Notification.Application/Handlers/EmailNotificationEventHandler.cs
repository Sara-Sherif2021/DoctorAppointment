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
    public class EmailNotificationEventHandler : IDistributedEventHandler<List<EmailNotificationDto>>, ITransientDependency
    {
        private readonly IEmailSender _emailSender;
        private readonly ILogger<EmailNotificationEventHandler> _logger;
        public EmailNotificationEventHandler(IEmailSender emailSender, ILogger<EmailNotificationEventHandler> logger)
        {
            _emailSender = emailSender;
            _logger = logger;
        }
        public async Task HandleEventAsync(List<EmailNotificationDto> emailNotifications)
        {
            foreach (var emailData in emailNotifications)
            {
                _logger.LogInformation($"New email EmailSubject: {emailData.EmailSubject},  ReceiverEmail: {emailData.ReceiverEmail}, EmailContent: {emailData.EmailContent}");
                //try
                //{
                //    await _emailSender.SendAsync(
                //       emailData.ReceiverEmail,     // target email address
                //       emailData.EmailSubject,      // subject
                //       emailData.EmailContent      // email body
                //   );
                //}
                //catch (Exception ex)
                //{
                //    _logger.LogException(ex);
                //}
            }
        }
    }
}
