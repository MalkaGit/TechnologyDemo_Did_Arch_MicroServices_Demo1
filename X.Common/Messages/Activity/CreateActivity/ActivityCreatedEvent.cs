using System;
using System.Collections.Generic;
using System.Text;
using X.Common.Messages.Common.Events;

namespace X.Common.Messages.Activity.CreateActivity
{

    /// <summary>
    /// </summary>
    /// <notes>
    /// 1.  events properties comes usally from commands
    /// 2.  event properties dont have setters but only getters
    /// 3.  protected constructor sets the properties 
    /// </notes>
    public class ActivityCreatedEvent : IAuthenticatedEvent
    {
        public Guid Id { get; }
        public Guid UserId { get; }
        public string Category { get; }
        public string Name { get; }
        public string Description { get; }
        public DateTime CreatedAt { get; }




        protected ActivityCreatedEvent()
        {
        }

        public ActivityCreatedEvent(Guid id, Guid userId,string category, string name,string description, DateTime createdAt)
        {
            Id = id;
            UserId = userId;
            Category = category;
            Name = name;
            Description = description;
            CreatedAt = createdAt;
        }
    }
}


