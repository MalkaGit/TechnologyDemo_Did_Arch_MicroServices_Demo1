using System;
using System.Collections.Generic;
using System.Text;
using X.Common.Messages.Common.Events;

namespace X.Common.Messages.MessagingTest
{
    public class TestMessagingRejectedEvent : IRejectedEvent
    {
        public string Email { get; }
        public string Code { get; }
        public string Reason { get; }

        protected TestMessagingRejectedEvent()
        {
        }

        public TestMessagingRejectedEvent(string email,string code, string reason)
        {
            Email   = email;
            Code    = code;
            Reason  = reason;
        }
    }
}
