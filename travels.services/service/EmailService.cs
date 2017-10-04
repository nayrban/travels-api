
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using travels.notifications;

namespace travels.services.service
{
    public interface IEmailService : IDisposable
    {
        Task SendEmail(NotificationMessage token);

    }
    public class EmailService : Disposable, IEmailService
    {
        private readonly CloudNotification cloudNotification;

        public EmailService(CloudNotification cloudNotification)
        {
            this.cloudNotification = cloudNotification;

        }

        public async Task SendEmail(NotificationMessage token)
        {
            await cloudNotification.sendNotification(token);
        }
    }
}
