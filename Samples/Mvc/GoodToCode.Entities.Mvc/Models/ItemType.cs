using System;
using System.Collections.Generic;

namespace GoodToCode.Entities.Web.Models
{
    public partial class ItemType
    {
        public int ItemTypeId { get; set; }
        public Guid ItemTypeKey { get; set; }
        public Guid ItemGroupKey { get; set; }
        public string ItemTypeName { get; set; }
        public string ItemTypeDescription { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }

        public virtual ItemGroup ItemGroupKeyNavigation { get; set; }
    }
}
