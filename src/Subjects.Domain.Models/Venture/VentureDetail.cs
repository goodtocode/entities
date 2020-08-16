using GoodToCode.Shared.Domain;
using System;
using System.ComponentModel.DataAnnotations;

namespace GoodToCode.Subjects.Models
{
    public class VentureDetail : DomainModel<IVentureDetail>, IVentureDetail
    {
        [Key]
        public Guid VentureDetailKey { get; set; }
        public Guid VentureKey { get; set; }
        public Guid DetailKey { get; set; }
        
        
    }
}
