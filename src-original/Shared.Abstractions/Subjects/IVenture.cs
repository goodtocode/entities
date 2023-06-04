﻿using GoodToCode.Shared.Domain;
using System;

namespace GoodToCode.Subjects.Models
{
    public interface IVenture : IDomainEntity<IVenture>
    {
        string VentureDescription { get; set; }
        Guid? VentureGroupKey { get; set; }
        Guid VentureKey { get; set; }
        string VentureName { get; set; }
        string VentureSlogan { get; set; }
        Guid? VentureTypeKey { get; set; }
    }
}