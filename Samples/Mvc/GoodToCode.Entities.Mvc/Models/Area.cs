using System;
using System.Collections.Generic;

namespace GoodToCode.Entities.Web.Models
{
    public partial class Area
    {
        public int AreaId { get; set; }
        public Guid AreaKey { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
