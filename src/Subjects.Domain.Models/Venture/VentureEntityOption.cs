using System;
using System.ComponentModel.DataAnnotations;

namespace GoodToCode.Subjects.Models
{
    public class VentureEntityOption : IVentureEntityOption
    {
        [Key]
        public int VentureEntityOptionId { get; set; }
        public Guid VentureEntityOptionKey { get; set; }
        public Guid OptionKey { get; set; }
        public Guid VentureKey { get; set; }
        public Guid EntityKey { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
