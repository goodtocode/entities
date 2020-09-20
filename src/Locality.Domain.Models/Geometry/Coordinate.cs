using GoodToCode.Shared.Models;
using System;
using System.ComponentModel.DataAnnotations;
using NetTopologySuite.Geometries;

namespace GoodToCode.Locality.Models
{
    public class Coordinate : DomainModel<ICoordinate>, ICoordinate
    {
        public override string PartitionKey { get; set; } = "Default";
        public override Guid RowKey { get { return CoordinateKey; } set { CoordinateKey = value; } }
        public Guid CoordinateKey { get; set; }
        public Point CoordinatePoint { get; set; }
    }
}
