using System;
using System.Collections.Generic;
using System.Text;
using X.Common.Messages.Common.Events;

namespace X.Common.Messages.User.CreateUser
{

    public class CreateUserRejectedEvent : IRejectedEvent
    {
        #region Properties

        /// <summary>
        /// which email was rejected
        /// </summary>
        public string Email { get; }
        public string Reason { get; }
        public string Code { get; }

        #endregion 

        #region Properties

        protected CreateUserRejectedEvent()
        {
        }

        public CreateUserRejectedEvent(string email,string reason, string code)
        {
            Email = email;
            Reason = reason;
            Code = code;
        }

        #endregion
    }
}
