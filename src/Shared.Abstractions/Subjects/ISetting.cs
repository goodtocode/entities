using GoodToCode.Shared.Models;
using System;

namespace GoodToCode.Subjects.Models
{
    public interface ISetting : IDomainModel<ISetting>
    {
        Guid SettingKey { get; set; }
        string SettingName { get; set; }
        int SettingTypeKey { get; set; }
        string SettingValue { get; set; }
    }
}