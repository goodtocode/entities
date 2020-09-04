using GoodToCode.Shared.Models;
using System;
using System.ComponentModel.DataAnnotations;
using NetTopologySuite.Geometries;

namespace GoodToCode.Locality.Models
{
    public class Line : DomainModel<ILine>, ILine
    {
        public override Guid RowKey { get { return LineKey; } protected set { LineKey = value; } }
        public Guid LineKey { get; set; }
        public Point StartPoint { get; set; }
        public Point EndPoint { get; set; }
    }
}
