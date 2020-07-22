using System;

namespace GoodToCode.Shared.Models
{
    public interface IArea
    {
        int AreaId { get; set; }
        Guid AreaKey { get; set; }
        DateTime CreatedDate { get; set; }
    }
}