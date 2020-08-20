using System;
using System.Collections.Generic;
using System.Text;
using X.Common.Messages.Common.Commands;

namespace X.Common.Messages.User.CreateUser
{
    /// <summary>
    /// Command to ceate new user
    /// </summary>
    /// <remarks>
    /// no need to authorized to run the command. This the interface implement ICommand and not IAuthorizedCommand.
    /// </remarks>
    public class CreateUserCommand : ICommand
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
    }
}
