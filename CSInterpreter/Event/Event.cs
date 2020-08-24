using System;
using System.Collections.Generic;

namespace CSInterpreter.Event
{
    class Event : IEvent
    {
        public string Id { get; set; }
        public DateTime Datetime { get; set; }
        public ICollection<IEvent> RelatedEvents { get; set; }
    }
}