﻿using System;
using System.Collections.Generic;
using System.Text;

namespace People.Business.Notifications
{
    public class Notification
    {
        public Notification(string message)
        {
            Message = message;
        }

        public string Message { get; }
    }
}
