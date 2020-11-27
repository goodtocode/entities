using GoodToCode.Shared.Domain;
using System;
using System.ComponentModel.DataAnnotations;

namespace GoodToCode.Locality.Models
{
    public class ResourceLocation : DomainEntity<IResourceLocation>, IResourceLocation
    {
        public override string PartitionKey { get; set; } = "Default";
        public override Guid RowKey { get { return ResourceLocationKey; } set { ResourceLocationKey = value; } }
        public Guid ResourceLocationKey { get; set; }
        public Guid ResourceKey { get; set; }
        public Guid LocationKey { get; set; }
        public Guid? LocationTypeKey { get; set; }
        
        
    }
}
