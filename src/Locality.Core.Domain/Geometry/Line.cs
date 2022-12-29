﻿using GoodToCode.Shared.Domain;
using System;
using System.ComponentModel.DataAnnotations;
using NetTopologySuite.Geometries;

namespace GoodToCode.Locality.Models
{
    public class Line : DomainEntity<ILine>, ILine
    {
        public override string PartitionKey { get; set; } = "Default";
        public override Guid RowKey { get { return LineKey; } set { LineKey = value; } }
        public Guid LineKey { get; set; }
        public Point StartPoint { get; set; }
        public Point EndPoint { get; set; }
    }
}
