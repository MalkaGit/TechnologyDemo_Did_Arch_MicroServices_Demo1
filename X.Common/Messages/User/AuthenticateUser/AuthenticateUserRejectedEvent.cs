using System;
using System.Collections.Generic;
using System.Text;
using X.Common.Messages.Common.Events;

namespace X.Common.Messages.User.AuthenticateUser
{
   
    /// <summary>
    /// fired when login to the system fails
    /// </summary>
    public class AuthenticateUserRejectedEvent : IRejectedEvent
    {
        public string Email { get; }
        public string Code { get; }
        public string Reason { get; }

        protected AuthenticateUserRejectedEvent()
        {
        }

        public AuthenticateUserRejectedEvent(string email,
            string code, string reason)
        {
            Email = email;
            Code = code;
            Reason = reason;
        }
    }
}
