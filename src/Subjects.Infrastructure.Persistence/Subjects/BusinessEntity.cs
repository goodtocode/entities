using System;

namespace GoodToCode.Subjects.Models
{
    public class BusinessEntity : Business, IBusiness
    {
        public virtual EntityEntity BusinessKeyNavigation { get; set; }
        public virtual RecordStateEntity RecordStateKeyNavigation { get; set; }
    }
}
