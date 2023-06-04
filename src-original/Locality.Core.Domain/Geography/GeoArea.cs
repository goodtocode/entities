﻿using GoodToCode.Shared.Domain;
using NetTopologySuite.Geometries;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GoodToCode.Locality.Models
{
    public class GeoArea : DomainEntity<IGeoArea>, IGeoArea
    {
        public override string PartitionKey { get; set; } = "Default";
        public override Guid RowKey { get { return GeoAreaKey; } set { GeoAreaKey = value; } }
        public Guid GeoAreaKey { get; set; }
        [Column(TypeName = "geometry")]
        public Geometry GeodeticArea { get; set; }
    }
}
