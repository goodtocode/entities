using GoodToCode.Shared.Domain;
using System;

namespace GoodToCode.Subjects.Models
{
    public interface IResource : IDomainModel<IResource>
    {
        string ResourceDescription { get; set; }
        Guid ResourceKey { get; set; }
        string ResourceName { get; set; }
    }
}