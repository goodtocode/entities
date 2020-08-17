using GoodToCode.Shared.Models;
using System;

namespace GoodToCode.Subjects.Models
{
    public interface ISettingType : IDomainModel<ISettingType>
    {
        Guid SettingTypeKey { get; set; }
        string SettingTypeName { get; set; }
    }
}