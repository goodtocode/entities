using GoodToCode.Shared.Models;
using System;

namespace GoodToCode.Subjects.Models
{
    public interface IResourceType : IDomainModel<IResourceType>
    {
        string ResourceTypeDescription { get; set; }
        Guid ResourceTypeKey { get; set; }
        string ResourceTypeName { get; set; }
    }
}