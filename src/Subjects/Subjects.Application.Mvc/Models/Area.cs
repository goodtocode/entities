using System;
using System.Collections.Generic;

namespace GoodToCode.Subjects.Models
{
    public partial class Area
    {
        public int AreaId { get; set; }
        public Guid AreaKey { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
