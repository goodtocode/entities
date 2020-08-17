using GoodToCode.Shared.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GoodToCode.Occurrences.Models
{
    public class EventResource : DomainModel<IEventResource>, IEventResource
    {
        [Key]
        public Guid EventResourceKey { get; set; }
        public Guid EventKey { get; set; }
        public Guid ResourceKey { get; set; }
        public Guid? ResourceTypeKey { get; set; }
    }
}
