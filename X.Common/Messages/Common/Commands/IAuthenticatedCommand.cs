using System;
using System.Collections.Generic;
using System.Text;

namespace X.Common.Messages.Common.Commands
{
    /// <summary>
    /// Command that can be executed only by authorized users.
    /// </summary>
    public interface IAuthenticatedCommand : ICommand
    {
        /// <summary>
        /// identifies the user who was authorized by the controller 
        /// </summary>
        Guid UserId { get; set; }
    }
}
