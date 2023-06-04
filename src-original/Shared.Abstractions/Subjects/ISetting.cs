using GoodToCode.Shared.Domain;
using System;

namespace GoodToCode.Subjects.Models
{
    public interface ISetting : IDomainEntity<ISetting>
    {
        Guid SettingKey { get; set; }
        string SettingName { get; set; }
        int SettingTypeKey { get; set; }
        string SettingValue { get; set; }
    }
}