﻿using GoodToCode.Shared.Domain;
using System;
using System.ComponentModel.DataAnnotations;
using NetTopologySuite.Geometries;

namespace GoodToCode.Locality.Models
{
    public class GeoDistance : DomainEntity<IGeoDistance>, IGeoDistance
    {
        public override string PartitionKey { get; set; } = "Default";
        public override Guid RowKey { get { return GeoDistanceKey; } set { GeoDistanceKey = value; } }
        public Guid GeoDistanceKey { get; set; }
        public Guid StartLatLongKey { get; set; }
        public Guid EndLatLongKey { get; set; }
    }
}
