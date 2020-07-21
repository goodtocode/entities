using System;

namespace GoodToCode.Subjects.Models
{
    public interface ISetting
    {
        DateTime CreatedDate { get; set; }
        DateTime ModifiedDate { get; set; }
        int SettingId { get; set; }
        Guid SettingKey { get; set; }
        string SettingName { get; set; }
        int SettingTypeKey { get; set; }
        string SettingValue { get; set; }
    }
}