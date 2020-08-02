using System;
using System.ComponentModel.DataAnnotations;

namespace GoodToCode.Subjects.Models
{
    public class EntityTimeRecurring : IEntityTimeRecurring
    {
        public int EntityTimeRecurringId { get; set; }
        [Key]
        public Guid EntityTimeRecurringKey { get; set; }
        public Guid EntityKey { get; set; }
        public Guid TimeRecurringKey { get; set; }
        public string DayName { get; set; }
        public string TimeName { get; set; }
        public Guid? TimeTypeKey { get; set; }
        public Guid RecordStateKey { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
