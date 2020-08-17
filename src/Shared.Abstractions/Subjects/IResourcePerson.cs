using GoodToCode.Shared.Models;
using System;

namespace GoodToCode.Subjects.Models
{
    public interface IResourcePerson : IDomainModel<IResourcePerson>
    {
        Guid PersonKey { get; set; }
        Guid ResourceKey { get; set; }
        Guid ResourcePersonKey { get; set; }
    }
}