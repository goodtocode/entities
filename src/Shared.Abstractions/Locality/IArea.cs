using System;

namespace GoodToCode.Locality.Models
{
    public interface IArea
    {
        int AreaId { get; set; }
        Guid AreaKey { get; set; }
        DateTime CreatedDate { get; set; }
    }
}