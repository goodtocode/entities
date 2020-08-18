using GoodToCode.Shared.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace GoodToCode.Locality.Models
{
    public class LocationType : DomainModel<ILocationType>, ILocationType
    {
        [Key]
        public Guid LocationTypeKey { get; set; }
        public string LocationTypeName { get; set; }
        public string LocationTypeDescription { get; set; }
    }
}
