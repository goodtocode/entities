using GoodToCode.Shared.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace GoodToCode.Locality.Models
{
    public class Location : DomainModel<ILocation>, ILocation
    {
        [Key]
        public Guid LocationKey { get; set; }
        public string LocationName { get; set; }
        public string LocationDescription { get; set; }
    }
}
