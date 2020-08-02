using System;

namespace GoodToCode.Subjects.Models
{
    public class EntityTimeRecurringEntity : EntityTimeRecurring, IEntityTimeRecurring
    {
        public virtual EntityEntity EntityKeyNavigation { get; set; }
        public virtual RecordStateEntity RecordStateKeyNavigation { get; set; }
    }
}
