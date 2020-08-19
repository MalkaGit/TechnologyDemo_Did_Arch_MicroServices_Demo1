using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace X.Common.Commands.Common
{
    /// <summary>
    /// executes a command that returns void asynchorinously
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <remarks>
    /// 1. command handlers are implemented in the the Services who consumes the command
    /// </remarks>
    public interface ICommandHandler<in T> where T : ICommand
    {
        Task HandleAsync(T command);
    }
}
