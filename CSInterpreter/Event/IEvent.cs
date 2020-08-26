using System;
using System.Collections.Generic;

namespace CSInterpreter.Event
{
    interface IEvent
    {
        string Id { get; set; }
        float Value { get; set; }
        string StringValue { get; set; }
        DateTime Datetime { get; set; }
        ICollection<IEvent> RelatedEvents { get; set; }
    }
}