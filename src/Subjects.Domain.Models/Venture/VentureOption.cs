using System;
using System.ComponentModel.DataAnnotations;

namespace GoodToCode.Subjects.Models
{
    public class VentureOption : IVentureOption
    {
        public int VentureOptionId { get; set; }
        [Key]
        public Guid VentureOptionKey { get; set; }
        public Guid VentureKey { get; set; }
        public Guid OptionKey { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
