
using System;
using System.ComponentModel.DataAnnotations;

namespace GoodToCode.Subjects.Models
{
    public class ResourceTimeRecurring : IResourceTimeRecurring
    {
        [Key]
        public Guid ResourceTimeRecurringKey { get; set; }
        public Guid ResourceKey { get; set; }
        public Guid TimeRecurringKey { get; set; }
        public string DayName { get; set; }
        public string TimeName { get; set; }
        public Guid? TimeTypeKey { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
