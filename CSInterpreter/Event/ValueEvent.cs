using System;
using System.Collections.Generic;

namespace CSInterpreter.Event
{
    class ValueEvent : IValueEvent
    {
        public string Id { get; set; }
        public DateTime Datetime { get; set; }
        public ICollection<IEvent> RelatedEvents { get; set; }
        public float MyValue { get; set; }
        public int CompareTo(float other)
        {
            return MyValue.CompareTo(other);
        }

    }
}