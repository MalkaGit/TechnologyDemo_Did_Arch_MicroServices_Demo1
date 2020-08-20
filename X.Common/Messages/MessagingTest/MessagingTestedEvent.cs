using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using X.Common.Messages.Common.Events;

namespace X.Common.Messages.MessagingTest
{

    ///<summary>
    /// event
    /// </summary>
    /// <remarks>
    /// </remarks>
    public class MessagingTestedEvent : IEvent
    {
        public string Email { get; set; }

    }
}
