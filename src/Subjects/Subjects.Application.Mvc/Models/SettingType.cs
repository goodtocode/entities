using System;
using System.Collections.Generic;

namespace GoodToCode.Subjects.Models
{
    public partial class SettingType
    {
        public int SettingTypeId { get; set; }
        public Guid SettingTypeKey { get; set; }
        public string SettingTypeName { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
