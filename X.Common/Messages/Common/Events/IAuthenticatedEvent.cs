using System;
using System.Collections.Generic;
using System.Text;

namespace X.Common.Messages.Common.Events
{

    // <summary>
    /// in order to run the command, the user has to be authenticated
    /// </summary>
    public interface IAuthenticatedEvent : IEvent
    {
        /// <summary>
        /// identifies the user who is authenticated to run the command
        /// </summary>
        Guid UserId { get; }
    }
}




