using GoodToCode.Shared.Domain;
using System;
using System.ComponentModel.DataAnnotations;
using NetTopologySuite.Geometries;

namespace GoodToCode.Locality.Models
{
    public class LatLong : DomainEntity<ILatLong>, ILatLong
    {
        public override string PartitionKey { get; set; } = "Default";
        public override Guid RowKey { get { return LatLongKey; } set { LatLongKey = value; } }
        public Guid LatLongKey { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
