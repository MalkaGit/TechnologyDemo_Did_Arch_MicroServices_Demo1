using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.Common.Messages.Common.Commands;
using X.Common.Messages.MessagingTest;

namespace X.MS.TestMessaging.ApiApp.MessageHandlers.MessagingTest
{
    public class TestMessagingCommandHandler : ICommandHandler<TestMessagingCommand>
    {
        #region ICommandHandler

        /// <summary>
        /// 
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public async Task HandleAsync(TestMessagingCommand command)
        {
            //step1:  dummay (to support async)
            await Task.CompletedTask; //dummay

            Console.WriteLine($"In TestMessagingCommadHandler. Dummy={command.Dummay}");

            return;
        }

        #endregion 
    }
}