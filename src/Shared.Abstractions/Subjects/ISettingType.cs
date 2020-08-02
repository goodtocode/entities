using System;

namespace GoodToCode.Subjects.Models
{
    public interface ISettingType
    {
        DateTime CreatedDate { get; set; }
        Guid SettingTypeKey { get; set; }
        string SettingTypeName { get; set; }
    }
}