using GoodToCode.Shared.Domain;
using System;
using System.ComponentModel.DataAnnotations;

namespace GoodToCode.Chronology.Models
{
    public class VentureSchedule : DomainEntity<IVentureSchedule>, IVentureSchedule
    {
        public override string PartitionKey { get; set; } = "Default";
        public override Guid RowKey { get { return VentureScheduleKey; } set { VentureScheduleKey = value; } }
        public Guid VentureScheduleKey { get; set; }
        public Guid VentureKey { get; set; }
        public Guid ScheduleKey { get; set; }
        public Guid? ScheduleTypeKey { get; set; }
        
        
    }
}
