using GoodToCode.Shared.Domain;
using System;

namespace GoodToCode.Subjects.Models
{
    public interface ISettingType : IDomainEntity<ISettingType>
    {
        Guid SettingTypeKey { get; set; }
        string SettingTypeName { get; set; }
    }
}