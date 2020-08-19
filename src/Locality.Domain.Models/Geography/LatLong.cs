﻿using GoodToCode.Shared.Models;
using System;
using System.ComponentModel.DataAnnotations;
using NetTopologySuite.Geometries;

namespace GoodToCode.Locality.Models
{
    public class LatLong : DomainModel<ILatLong>, ILatLong
    {
        [Key]
        public Guid LatLongKey { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
