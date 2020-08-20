using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace X.Common.Messages.Common.Commands
{
    /// <summary>
    /// </summary>
    /// <typeparam name="T">the type of te command that the handler will process</typeparam>
    /// <remarks>
    /// 1. command handler processes a command async and return void
    /// 2. command handles are implemented by services
    /// </remarks>
    public interface ICommandHandler<in T> where T : ICommand
    {
        Task HandleAsync(T command);
    }
}
