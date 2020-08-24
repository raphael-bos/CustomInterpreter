using System;
using System.Collections.Generic;

namespace CSInterpreter.Event
{
    interface IEvent
    {
        string Id { get; set; }
        DateTime Datetime { get; set; }
        ICollection<IEvent> RelatedEvents { get; set; }
    }
}