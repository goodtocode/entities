using GoodToCode.Shared.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace GoodToCode.Locality.Models
{
    public class Location : DomainModel<ILocation>, ILocation
    {
        public override Guid RowKey { get { return LocationKey; } protected set { LocationKey = value; } }
        public Guid LocationKey { get; set; }
        public string LocationName { get; set; }
        public string LocationDescription { get; set; }
    }
}
