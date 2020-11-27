using GoodToCode.Shared.Domain;
using System;

namespace GoodToCode.Subjects.Models
{
    public interface IResourcePerson : IDomainEntity<IResourcePerson>
    {
        Guid PersonKey { get; set; }
        Guid ResourceKey { get; set; }
        Guid ResourcePersonKey { get; set; }
    }
}