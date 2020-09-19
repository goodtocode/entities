using GoodToCode.Shared.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace GoodToCode.Subjects.Models
{
    public class VentureOption : DomainModel<IVentureOption>, IVentureOption
    {
        public override Guid RowKey { get { return VentureOptionKey; } set { VentureOptionKey = value; } }
        public Guid VentureOptionKey { get; set; }
        public Guid VentureKey { get; set; }
        public Guid OptionKey { get; set; }
        
        
    }
}
