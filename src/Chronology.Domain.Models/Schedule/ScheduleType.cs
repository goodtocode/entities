using GoodToCode.Shared.Domain;
using System;
using System.ComponentModel.DataAnnotations;

namespace GoodToCode.Chronology.Models
{
    public class ScheduleType : DomainEntity<IScheduleType>, IScheduleType
    {
        public override string PartitionKey { get; set; } = "Default";
        public override Guid RowKey { get { return ScheduleTypeKey; } set { ScheduleTypeKey = value; } }
        public Guid ScheduleTypeKey { get; set; }        
        public string ScheduleTypeName { get; set; }
        public string ScheduleTypeDescription { get; set; }
    }
}
