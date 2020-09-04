﻿using GoodToCode.Shared.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using NetTopologySuite.Geometries;

namespace GoodToCode.Locality.Models
{
    public class GeoLocation : DomainModel<IGeoLocation>, IGeoLocation
    {
        public override Guid RowKey { get { return GeoLocationKey; } protected set { GeoLocationKey = value; } }
        public Guid GeoLocationKey { get; set; }
        public Guid LatLongKey { get; set; }
        public Point Elevation { get; set; }

    }
}
