using System;
using System.Collections.Generic;
using System.Text;

namespace X.Common.Commands.Common
{
    /// <summary>
    /// in order to run the command, the user has to be authenticated
    /// </summary>
    public interface IAuthenticatedCommand : ICommand
    {
        /// <summary>
        /// identifies the user who is authenticated to run the command
        /// </summary>
        Guid UserId { get; set; }
    }
}
