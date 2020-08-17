﻿using GoodToCode.Shared.Models;
using System;

namespace GoodToCode.Locality.Models
{
    public class Location : DomainModel<ILocation>, ILocation
    {
        public Guid LocationKey { get; set; }
        public string LocationName { get; set; }
        public string LocationDescription { get; set; }
    }
}