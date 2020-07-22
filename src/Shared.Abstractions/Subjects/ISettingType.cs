using System;

namespace GoodToCode.Shared.Models
{
    public interface ISettingType
    {
        DateTime CreatedDate { get; set; }
        int SettingTypeId { get; set; }
        Guid SettingTypeKey { get; set; }
        string SettingTypeName { get; set; }
    }
}