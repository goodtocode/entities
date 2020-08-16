using System;

namespace GoodToCode.Locality.Domain.Models
{
    public class Location
    {
        public Guid LocationKey { get; set; }
        public string LocationName { get; set; }
        public string LocationDescription { get; set; }
    }
}
