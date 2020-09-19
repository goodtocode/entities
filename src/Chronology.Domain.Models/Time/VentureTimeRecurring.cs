using GoodToCode.Shared.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace GoodToCode.Chronology.Models
{
    public class VentureTimeRecurring : DomainModel<IVentureTimeRecurring>, IVentureTimeRecurring
    {
        public override Guid RowKey { get { return VentureTimeRecurringKey; } set { VentureTimeRecurringKey = value; } }
        public Guid VentureTimeRecurringKey { get; set; }
        public Guid VentureKey { get; set; }
        public Guid TimeRecurringKey { get; set; }
        public string DayName { get; set; }
        public string TimeName { get; set; }
        public Guid? TimeTypeKey { get; set; }
        
        
    }
}
