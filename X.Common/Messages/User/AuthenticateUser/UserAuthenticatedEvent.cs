using System;
using System.Collections.Generic;
using System.Text;
using X.Common.Messages.Common.Events;

namespace X.Common.Messages.User.AuthenticateUser
{
    public class UserAuthenticatedEvent : IEvent
    {
        #region Properties 
        public string Email { get; }

        //no need for password

        #endregion

        #region Constructor

        protected UserAuthenticatedEvent()
        {
        }

        public UserAuthenticatedEvent(string email)
        {
            Email = email;
        }

        #endregion
    }
}
