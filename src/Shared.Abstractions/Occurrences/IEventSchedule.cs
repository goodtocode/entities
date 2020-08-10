using System;

namespace GoodToCode.Occurrences.Models
{
    public interface IEventSchedule
    {
        DateTime CreatedDate { get; set; }
        Guid EventKey { get; set; }
        Guid EventScheduleKey { get; set; }
        DateTime ModifiedDate { get; set; }
        
        Guid ScheduleKey { get; set; }
        Guid? ScheduleTypeKey { get; set; }
    }
}