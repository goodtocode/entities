using System;
using System.Collections.Generic;

namespace GoodToCode.Chronology.Models
{
    public class ScheduleType
    {
        public Guid ScheduleTypeKey { get; set; }
        public string ScheduleTypeName { get; set; }
        public string ScheduleTypeDescription { get; set; }
    }
}
