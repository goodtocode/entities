using GoodToCode.Shared.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace GoodToCode.Chronology.Models
{
    public class VentureSchedule : DomainModel<IVentureSchedule>, IVentureSchedule
    {
        public override Guid RowKey { get { return VentureScheduleKey; } protected set { VentureScheduleKey = value; } }
        public Guid VentureScheduleKey { get; set; }
        public Guid VentureKey { get; set; }
        public Guid ScheduleKey { get; set; }
        public Guid? ScheduleTypeKey { get; set; }
        
        
    }
}
