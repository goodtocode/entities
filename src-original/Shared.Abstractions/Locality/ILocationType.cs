﻿using GoodToCode.Shared.Domain;
using System;
using System.Collections.Generic;

namespace GoodToCode.Locality.Models
{
    public interface ILocationType : IDomainEntity<ILocationType>
    {        
        string LocationTypeDescription { get; set; }
        Guid LocationTypeKey { get; set; }
        string LocationTypeName { get; set; }
        
    }
}