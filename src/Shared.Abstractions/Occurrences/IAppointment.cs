using System;
using System.Collections.Generic;

namespace GoodToCode.Occurrences.Models
{
    public interface IAppointment
    {
        string AppointmentDescription { get; set; }
        int AppointmentId { get; set; }
        Guid AppointmentKey { get; set; }
        string AppointmentName { get; set; }
        DateTime CreatedDate { get; set; }
        DateTime ModifiedDate { get; set; }
        Guid RecordStateKey { get; set; }
        Guid? SlotLocationKey { get; set; }
        Guid? SlotResourceKey { get; set; }
        Guid TimeRangeKey { get; set; }
    }
}