using System;
using System.Collections.Generic;
using X.Common.Messages.Common.Commands;

namespace X.Common.Messages.MessagingTest
{
   


    /// <summary>
    /// Command to test messaging
    /// </summary>
    /// <remarks>
    /// no need to authorized to run the command. This the interface implement ICommand and not IAuthorizedCommand.
    /// </remarks>
    public class TestMessagingCommand : ICommand
    {
        public string Dummay { get; set; }
    }
}
