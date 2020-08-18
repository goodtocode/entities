using GoodToCode.Shared.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.Drawing;

namespace GoodToCode.Locality.Models
{
    public class PointCoordinate : DomainModel<IPointCoordinate>, IPointCoordinate
    {
        [Key]
        public Guid PointCoordinateKey { get; set; }
        public Point Coordinate { get; set; }
    }
}
