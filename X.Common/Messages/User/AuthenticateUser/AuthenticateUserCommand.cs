using System;
using System.Collections.Generic;
using System.Text;
using X.Common.Messages.Common.Commands;

namespace X.Common.Messages.User.AuthenticateUser
{
    /// <summary>
    /// command to allow user to login
    /// </summary>
    /// <remarks>
    /// no need to authorized to run the command. This the interface implement ICommand and not IAuthorizedCommand.
    /// </remarks>
    public class AuthenticateUserCommand : ICommand
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
