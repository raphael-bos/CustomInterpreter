using System;
using System.Collections.Generic;

namespace CSInterpreter.Event
{
    class GenericEvent : IEvent
    {
        public string Id { get; set; }
        public float Value { get; set; }
        public string StringValue {get; set; }
        public DateTime Datetime { get; set; }
        public ICollection<IEvent> RelatedEvents { get; set; }
    }
}