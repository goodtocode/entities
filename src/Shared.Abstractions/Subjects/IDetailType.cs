using GoodToCode.Shared.Models;
using System;

namespace GoodToCode.Subjects.Models
{
    public interface IDetailType : IDomainModel<IDetailType>
    {
        string DetailTypeDescription { get; set; }
        Guid DetailTypeKey { get; set; }
        string DetailTypeName { get; set; }
    }
}