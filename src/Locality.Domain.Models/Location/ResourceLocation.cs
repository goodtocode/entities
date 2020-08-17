using GoodToCode.Shared.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace GoodToCode.Locality.Models
{
    public class ResourceLocation : DomainModel<IResourceLocation>, IResourceLocation
    {
        [Key]
        public Guid ResourceLocationKey { get; set; }
        public Guid ResourceKey { get; set; }
        public Guid LocationKey { get; set; }
        public Guid? LocationTypeKey { get; set; }
        
        
    }
}
