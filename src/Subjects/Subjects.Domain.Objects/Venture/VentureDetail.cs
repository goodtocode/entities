using System;
using System.Collections.Generic;

namespace GoodToCode.Subjects.Models
{
    public partial class VentureDetail : IVentureDetail
    {
        public int VentureDetailId { get; set; }
        public Guid VentureDetailKey { get; set; }
        public Guid VentureKey { get; set; }
        public Guid DetailKey { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }

        public virtual Detail DetailKeyNavigation { get; set; }
        public virtual Venture VentureKeyNavigation { get; set; }
    }
}
