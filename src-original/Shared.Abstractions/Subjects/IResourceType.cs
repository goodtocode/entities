using GoodToCode.Shared.Domain;
using System;

namespace GoodToCode.Subjects.Models
{
    public interface IResourceType : IDomainEntity<IResourceType>
    {
        string ResourceTypeDescription { get; set; }
        Guid ResourceTypeKey { get; set; }
        string ResourceTypeName { get; set; }
    }
}