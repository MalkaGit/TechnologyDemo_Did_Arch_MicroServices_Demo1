using System;
using System.Collections.Generic;
using System.Text;
using X.Common.Commands.Common;

namespace X.Common.Commands
{


    /// <summary>
    /// command to allow user to login
    /// </summary>
    /// <remarks>
    /// no need to authorized to run the command. This the interface implement ICommand and not IAuthorizedCommand.
    /// </remarks>
    public class AuthenticateUser : ICommand
    {
        public string Email         { get; set; }
        public string Password      { get; set; }
    }
}
