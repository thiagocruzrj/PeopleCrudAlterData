using People.Business.Notifications;
using System;
using System.Collections.Generic;
using System.Text;

namespace People.Business.Interfaces
{
    public interface INotifier
    {
        bool HasNotification();
        List<Notification> GetNotifications();
        void Handle(Notification notification);
    }
}
