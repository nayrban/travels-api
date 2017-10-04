using travels.utilities.Utils;
using System;
using System.Collections.Generic;

namespace travels.notifications
{
    public class NotificationMessage
    {
        public string Message { get; set; }

        public string Title { get; set; }
    
        public string To { get; set; }

        public string Name { get; set; }

        public List<string> CustomParameters { get; set; }

        public List<string> NotificationKeyList { get; set; }

        public NotificationType NotificationType { get; set; }
    }
}
