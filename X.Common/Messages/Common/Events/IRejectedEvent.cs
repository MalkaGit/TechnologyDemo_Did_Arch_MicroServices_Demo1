using System;
using System.Collections.Generic;
using System.Text;

namespace X.Common.Messages.Common.Events
{

    /// <summary>
    /// Error handling (for critical exceptions or validatin errors)
    /// Other services want to react accordingly.
    /// 
    /// rejected events are  fired by service to indicate that the the handler of the command failed 
    /// eg, user authentication failed due to invalid credentials
    /// eg, user was not created because email already exists
    /// </summary>
    /// <remakrs>
    /// 0.  there will be errors
    ///     
    /// 1.  rejected events usually hold Reason (string) property 
    /// 2.  rejected evnets hols erorr Code.
    ///     error code is usually an enum.
    ///     here we use string for the simplicity.
    ///     the Code can be used by cient app to create friencdly localized user message.
    ///     
    /// 2,  rejected evetns may hold some pther properties form the command.
    ///     eg: Username on AuthenticateUser rejected.
    ///     this allows the client app to create localized friendly user message.

    /// 2.  rejected event properties gave getters but dont have setters.
    /// 3.  public constructor sets these properties 
    /// 4.  protected argumentless constructor is used for sertialization only
    /// </remakrs>
    public interface IRejectedEvent : IEvent
    {
        /// <summary>
        /// the Message telling why the failure happened
        /// </summary>
        string Reason { get; }


        /// <summary>
        /// error code (usually an enum)
        /// can be used bby api caller to create localized friendly user message
        /// </summary>
        string Code { get; }
    }
}
