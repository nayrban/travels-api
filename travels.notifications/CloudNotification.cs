using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace travels.notifications
{
    public interface CloudNotification
    {
        Task sendNotification(NotificationMessage message);
    }
}
