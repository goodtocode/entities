
using GoodToCode.Shared.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace GoodToCode.Chronology.Models
{
    public class ResourceTimeRecurring : DomainModel<IResourceTimeRecurring>, IResourceTimeRecurring
    {
        [Key]
        public Guid ResourceTimeRecurringKey { get; set; }
        public Guid ResourceKey { get; set; }
        public Guid TimeRecurringKey { get; set; }
        public string DayName { get; set; }
        public string TimeName { get; set; }
        public Guid? TimeTypeKey { get; set; }
    }
}
