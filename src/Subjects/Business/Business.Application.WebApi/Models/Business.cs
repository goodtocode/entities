using System;
using System.Collections.Generic;

namespace GoodToCode.Business
{
    public partial class Business
    {
        public int BusinessId { get; set; }
        public Guid BusinessKey { get; set; }
        public string BusinessName { get; set; }
        public string TaxNumber { get; set; }
        public Guid RecordStateKey { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
