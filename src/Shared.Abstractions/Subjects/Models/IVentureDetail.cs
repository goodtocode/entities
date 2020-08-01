using System;

namespace GoodToCode.Subjects.Models
{
    public interface IVentureDetail
    {
        DateTime CreatedDate { get; set; }
        Guid DetailKey { get; set; }
        DateTime ModifiedDate { get; set; }
        int VentureDetailId { get; set; }
        Guid VentureDetailKey { get; set; }
        Guid VentureKey { get; set; }
    }
}