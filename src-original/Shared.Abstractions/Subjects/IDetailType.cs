using GoodToCode.Shared.Domain;
using System;

namespace GoodToCode.Subjects.Models
{
    public interface IDetailType : IDomainEntity<IDetailType>
    {
        string DetailTypeDescription { get; set; }
        Guid DetailTypeKey { get; set; }
        string DetailTypeName { get; set; }
    }
}