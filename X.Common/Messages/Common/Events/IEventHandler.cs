using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace X.Common.Messages.Common.Events
{
    /// <summary>
    /// evebts are publsihed to the message bus by other services.
    /// micro services and API gaetway can implement event handles 
    /// and subscribe to the to the message bus to get notification 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IEventHandler<in T> where T : IEvent
    {
        Task HandleAsync(T @event);
    }
}
