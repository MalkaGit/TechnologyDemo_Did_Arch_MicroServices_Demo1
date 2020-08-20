using System;
using System.Collections.Generic;
using System.Text;
using X.Common.Messages.Common.Events;

namespace X.Common.Messages.Activity.CreateActivity
{

    public class CreateActivityRejectedEvent : IRejectedEvent
    {
        public Guid Id { get; }
        public string Reason { get; }
        public string Code { get; }

        protected CreateActivityRejectedEvent()
        {
        }

        public CreateActivityRejectedEvent(Guid id, string reason, string code)
        {
            Id = id;
            Reason = reason;
            Code = code;
        }
    }
}
