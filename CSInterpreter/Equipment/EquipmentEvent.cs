using System;

namespace CSInterpreter.Equipment
{
    class EquipmentEvent
    {
        public int Id { get; set; }
        public DateTime InsertTime { get; set; }
        public string Guide { get; set; }
        public string Tag { get; set; }
        public DateTime EventTime { get; set; }
        public string SerialNumber { get; set; }
        public string Value { get; set; }
        public string Hourmeter { get; set; }
    }
}