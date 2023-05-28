using GoodToCode.Shared.Domain;
using System;
using System.ComponentModel.DataAnnotations;

namespace GoodToCode.Chronology.Models
{
    public class VentureTimeRecurring : DomainEntity<IVentureTimeRecurring>, IVentureTimeRecurring
    {
        public override string PartitionKey { get; set; } = "Default";
        public override Guid RowKey { get { return VentureTimeRecurringKey; } set { VentureTimeRecurringKey = value; } }
        public Guid VentureTimeRecurringKey { get; set; }
        public Guid VentureKey { get; set; }
        public Guid TimeRecurringKey { get; set; }
        public string DayName { get; set; }
        public string TimeName { get; set; }
        public Guid? TimeTypeKey { get; set; }
        
        
    }
}
