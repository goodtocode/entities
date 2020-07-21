using System;
using System.Collections.Generic;

namespace GoodToCode.Subjects.Models
{
    public partial class LocationArea : ILocationArea
    {
        public int LocationAreaId { get; set; }
        public Guid LocationAreaKey { get; set; }
        public Guid LocationKey { get; set; }
        public Guid AreaKey { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }

        public virtual Location LocationKeyNavigation { get; set; }
    }
}
