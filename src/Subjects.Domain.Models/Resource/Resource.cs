
using GoodToCode.Shared.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace GoodToCode.Subjects.Models
{
    public class Resource : DomainModel<IResource>, IResource
    {
        public override Guid RowKey { get { return ResourceKey; } protected set { ResourceKey = value; } }
        public Guid ResourceKey { get; set; }
        public string ResourceName { get; set; }
        public string ResourceDescription { get; set; }
    }
}
