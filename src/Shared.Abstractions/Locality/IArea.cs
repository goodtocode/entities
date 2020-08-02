using System;

namespace GoodToCode.Locality.Models
{
    public interface IArea
    {
        Guid AreaKey { get; set; }
        DateTime CreatedDate { get; set; }
    }
}