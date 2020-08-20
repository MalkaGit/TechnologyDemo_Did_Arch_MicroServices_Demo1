using System;
using System.Collections.Generic;
using System.Text;

namespace X.Common.Messages.Common.Events
{ 
    /// <summary>
    /// Marker interface
    /// </summary>
    /// <notes>
    /// 0.  events are fired from servuce to other service or from service to API Gateway controller
    /// 1.  the properties of the events come from the command 
    /// 2.  the properties of the events have gettters but dont have setters 
    /// 3.  public constructor sets these properties 
    /// 4.  protected argumentless constructor is used for sertialization only
    /// </notes>
    public interface IEvent
    {
    }
}
