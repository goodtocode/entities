using System;
using System.Collections.Generic;

namespace GoodToCode.Shared.Models
{
    public partial class Business : IBusiness
    {
        public int BusinessId { get; set; }
        public Guid BusinessKey { get; set; }
        public string BusinessName { get; set; }
        public string TaxNumber { get; set; }
        public Guid RecordStateKey { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }

        public virtual Entity BusinessKeyNavigation { get; set; }
        public virtual RecordState RecordStateKeyNavigation { get; set; }
    }
}
