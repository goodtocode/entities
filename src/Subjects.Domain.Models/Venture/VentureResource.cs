using System;
using System.ComponentModel.DataAnnotations;

namespace GoodToCode.Subjects.Models
{
    public class VentureResource : IVentureResource
    {
        [Key]
        public Guid VentureResourceKey { get; set; }
        public Guid VentureKey { get; set; }
        public Guid ResourceKey { get; set; }
        public Guid? ResourceTypeKey { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
