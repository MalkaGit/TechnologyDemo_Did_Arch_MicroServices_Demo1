using System;
using System.Collections.Generic;
using System.Text;
using X.Common.Messages.Common.Commands;

namespace X.Common.Messages.Activity.CreateActivity
{
    public class CreateActivityCommand : IAuthenticatedCommand
    {
        /// <summary>
        /// the new activity id 
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// identifies the user who is authenticated to run the command
        /// </summary>
        public Guid UserId { get; set; }
        public string Category { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
