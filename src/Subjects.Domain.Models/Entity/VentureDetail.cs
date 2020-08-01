using System;

namespace GoodToCode.Subjects.Models
{
    public class VentureDetail : IVentureDetail
    {
        public int VentureDetailId { get; set; }
        public Guid VentureDetailKey { get; set; }
        public Guid VentureKey { get; set; }
        public Guid DetailKey { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
