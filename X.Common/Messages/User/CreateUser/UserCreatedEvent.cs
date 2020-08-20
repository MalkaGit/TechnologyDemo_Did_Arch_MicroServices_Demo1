using System;
using System.Collections.Generic;
using System.Text;
using X.Common.Messages.Common.Events;

namespace X.Common.Messages.User.CreateUser
{
    public class UserCreatedEvent : IEvent
    {
        #region Properties

        public string Email { get; }
        public string Name { get; }

        //we dont want to have the password here

        #endregion

        #region Constructor

        protected UserCreatedEvent()
        {
        }

        public UserCreatedEvent(string email, string name)
        {
            Email = email;
            Name = name;
        }

        #endregion
    }
}
