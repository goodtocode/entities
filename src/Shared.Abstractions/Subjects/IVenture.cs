using GoodToCode.Shared.Models;
using System;

namespace GoodToCode.Subjects.Models
{
    public interface IVenture : IDomainModel<IVenture>
    {
        string VentureDescription { get; set; }
        Guid? VentureGroupKey { get; set; }
        Guid VentureKey { get; set; }
        string VentureName { get; set; }
        string VentureSlogan { get; set; }
        Guid? VentureTypeKey { get; set; }
    }
}