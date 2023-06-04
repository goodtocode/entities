﻿using GoodToCode.Shared.Domain;
using System;

namespace GoodToCode.Locality.Models
{
    public interface ILocation : IDomainEntity<ILocation>
    {
        
        string LocationDescription { get; set; }
        Guid LocationKey { get; set; }
        string LocationName { get; set; }
        
        
    }
}