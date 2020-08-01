using System;
using System.Collections.Generic;

namespace GoodToCode.Chronology.Models
{
    public interface IScheduleType
    {
        DateTime CreatedDate { get; set; }
        DateTime ModifiedDate { get; set; }
        string ScheduleTypeDescription { get; set; }
        int ScheduleTypeId { get; set; }
        Guid ScheduleTypeKey { get; set; }
        string ScheduleTypeName { get; set; }
    }
}