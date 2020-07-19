using System;
using System.Collections.Generic;

namespace GoodToCode.Entities.WebApi1.Models
{
    public partial class Area
    {
        public int AreaId { get; set; }
        public Guid AreaKey { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
