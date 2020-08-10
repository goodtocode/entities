using System;
using System.Collections.Generic;

namespace GoodToCode.Subjects.Models
{
    public interface IVenture
    {
        DateTime CreatedDate { get; set; }
        DateTime ModifiedDate { get; set; }
        
        string VentureDescription { get; set; }
        Guid? VentureGroupKey { get; set; }
        Guid VentureKey { get; set; }
        string VentureName { get; set; }
        string VentureSlogan { get; set; }
        Guid? VentureTypeKey { get; set; }
    }
}