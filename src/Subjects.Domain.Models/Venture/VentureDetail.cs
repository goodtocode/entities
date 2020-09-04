using GoodToCode.Shared.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace GoodToCode.Subjects.Models
{
    public class VentureDetail : DomainModel<IVentureDetail>, IVentureDetail
    {
        public override Guid RowKey { get { return VentureDetailKey; } protected set { VentureDetailKey = value; } }
        public Guid VentureDetailKey { get; set; }
        public Guid VentureKey { get; set; }
        public Guid DetailKey { get; set; }
        
        
    }
}
