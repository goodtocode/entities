using GoodToCode.Shared.Domain;
using System;
using System.ComponentModel.DataAnnotations;

namespace GoodToCode.Chronology.Models
{
    public class TimeType : DomainEntity<ITimeType>, ITimeType
    {
        public override string PartitionKey { get; set; } = "Default";
        public override Guid RowKey { get { return TimeTypeKey; } set { TimeTypeKey = value; } }
        public Guid TimeTypeKey { get; set; }
        public string TimeTypeName { get; set; }
        public string TimeTypeDescription { get; set; }
        public int TimeBehavior { get; set; }
    }
}
