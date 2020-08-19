using GoodToCode.Shared.Models;
using System;
using System.ComponentModel.DataAnnotations;
using NetTopologySuite.Geometries;

namespace GoodToCode.Locality.Models
{
    public class Coordinate : DomainModel<ICoordinate>, ICoordinate
    {
        [Key]
        public Guid CoordinateKey { get; set; }
        public Point CoordinatePoint { get; set; }
    }
}
