using System;
using System.ComponentModel.DataAnnotations;

namespace GoodToCode.Subjects.Models
{
    public class Venture : IVenture
    {
        [Key]
        public Guid VentureKey { get; set; }
        public Guid? VentureGroupKey { get; set; }
        public Guid? VentureTypeKey { get; set; }
        public string VentureName { get; set; }
        public string VentureDescription { get; set; }
        public string VentureSlogan { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
