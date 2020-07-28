using System;
using System.Collections.Generic;

namespace GoodToCode.Shared.Models
{
    public partial class Setting : ISetting
    {
        public Setting()
        {
        }

        public int SettingId { get; set; }
        public Guid SettingKey { get; set; }
        public int SettingTypeKey { get; set; }
        public string SettingName { get; set; }
        public string SettingValue { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
