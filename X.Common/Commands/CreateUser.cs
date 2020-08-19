using System;
using System.Text;
using X.Common.Commands.Common;

namespace X.Common.Commands
{
    /// <summary>
    /// Command to ceate new user
    /// </summary>
    /// <remarks>
    /// no need to authorized to run the command. This the interface implement ICommand and not IAuthorizedCommand.
    /// </remarks>
    public class CreateUser :ICommand
    {
        public string Email         { get; set; }
        public string Password      { get; set; }
        public string Name          { get; set; }
    }
}
