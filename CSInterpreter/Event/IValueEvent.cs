using System;
using System.Collections.Generic;

namespace CSInterpreter.Event
{
    interface IValueEvent : IEvent, IComparable<float>
    {

    }
}